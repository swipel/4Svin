using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmDataController.Sockets;

namespace FarmDataController
{
    class Program
    {
        private readonly LSWebSocket _socketApi = new LSWebSocket();
        
        static void Main(string[] args)
        {
            //TODO Should be a thread
            LSWebSocket.StartServer();
        }
    }
}
