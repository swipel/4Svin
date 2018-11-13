using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using FarmAPI.Models;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FarmAPI.WebSocket
{
    public class ApiSocket
    {
        public string FeedAnimal(SocketMessage socketMessageObject)
        {
            //Send request to LS to start feeder
            var feedResponse = SendSocketMessage(socketMessageObject);
            return feedResponse;
        }

        public string Statistics(SocketMessage socketMessageObject)
        {
            //Send request to LS to get new statistics
            var statisticsResponse = SendSocketMessage(socketMessageObject);
            return statisticsResponse;
            //TODO read statistics SensorId
        }
        
        //Send json to ls
        private string SendSocketMessage(SocketMessage socketObject)
        {  
            byte[] bytes = new byte[1024];  
  
            try  
            {  
                //Remote server ip
                IPHostEntry host = Dns.GetHostEntry("localhost");  
                
                //Get first ip in array
                IPAddress ipAddress = host.AddressList[0];
                
                //Use ip and port
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);  
  
                //Create socket connection
                Socket sender = new Socket(ipAddress.AddressFamily,  
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    //Convert socketMessage to json
                    string json = JsonConvert.SerializeObject(socketObject);
                    
                    //Make byte[] of string <EOF> is used so LS know when transfer is done
                    byte[] msg = Encoding.ASCII.GetBytes(json+"<EOF>");
                    
                    //Send message
                    int bytesSent = sender.Send(msg);

                    //Receive answear from LS
                    int bytesRec = sender.Receive(bytes);
                
                    //Convert byte[] to string
                    return Encoding.ASCII.GetString(bytes, 0, bytesRec); 

                }
                catch (ArgumentNullException ane)
                {
                    throw ane;
                }
                catch (SocketException se)
                {
                    throw se;
                    
                }
                catch (Exception e)
                {
                    throw e;
                    
                }
            }  
            catch (Exception e)  
            {  
                throw e;
            }  
        } 
    }
}