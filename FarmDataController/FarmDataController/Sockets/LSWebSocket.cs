using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FarmDataController.Enum;
using FarmDataController.Managers;
using FarmDataController.Models;
using Newtonsoft.Json;

namespace FarmDataController.Sockets
{
    class LSWebSocket
    {
        public void StartServer(string ip)
        {
            //Start server
            IPHostEntry host = Dns.GetHostEntry(ip);  
            //Get first host in array
            IPAddress ipAddress = host.AddressList[0];
            //Use host and 11000 port
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);    
        
            try {
                //Create server and start listener
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);  
                listener.Bind(localEndPoint);  
                listener.Listen(10);

                while (true)
                {
                    //Wait for connection
                    Socket handler = listener.Accept();

                    //Data from byte array
                    string data = null;
                    
                    //Bytes from client
                    byte[] bytes = null;

                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        //Convert byte[] to string and stop when <E0F> is recived
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    //Method to handle where the data should go and response to client
                    string response = HandleData(data);
                    
                    //Convert json string to byte[]
                    byte[] msg = Encoding.ASCII.GetBytes(response);  
                    
                    //Send message to client
                    handler.Send(msg); 
                }
                
            }  
            catch (Exception e)  
            {  
                //TODO log error to db
            }   
        }

        private string HandleData(string data)
        {
            //Remove last 5 char from string
           data = data.Substring(0, data.Length - 5);
            
            //Convert json string to object
           SocketReceive socketObject = JsonConvert.DeserializeObject<SocketReceive>(data);

            //Check object enum
            if (socketObject.Type == TypeEnum.Feed)
            {
                   MCManager mcm = MCManager.Instance;
                   //call MCManager and serialize return 
                   return JsonConvert.SerializeObject(mcm.SocketFeed(socketObject.FarmId));
            }
            else if (socketObject.Type == TypeEnum.Statistics)
            {
                //TODO GET STATISTICS
            }
            
            return "Error";
        }
    }
}
