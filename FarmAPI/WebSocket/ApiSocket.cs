using System;
using System.Collections.Generic;
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
            var feedResponse = SendSocketMessage(socketMessageObject);
            
            return feedResponse;
        }

        public void GetStatisticsFromLs()
        {
            //TODO read statistics SensorId
        }
        
        public string SendSocketMessage(SocketMessage socketObject)
        {  
            byte[] bytes = new byte[1024];  
  
            try  
            {  
                IPHostEntry host = Dns.GetHostEntry("localhost");  
                IPAddress ipAddress = host.AddressList[0];  
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);  
  
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
                    
                    // Console.WriteLine("Echoed = {0}",
                     //   Encoding.ASCII.GetString(bytes, 0, bytesRec));

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }  
            catch (Exception e)  
            {  
                Console.WriteLine(e.ToString());
            }  
            return null;
        } 
    }
}