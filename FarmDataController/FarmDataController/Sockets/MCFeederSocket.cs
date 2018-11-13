using FarmDataController.Interfaces;
using FarmDataController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FarmDataController.Mocking;

namespace FarmDataController.Sockets
{
    class MCFeederSocket : ISocket
    {
        public IPAddress Ip { get; set; }
        public TcpListener Server { get; set; }
        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }
        public Byte[] IncommingData { get; set; }
        public List<Sensor> Sensors { get; set; }

        public bool FeederFeed()
        {
            Feeder feeder = new Feeder();
            return feeder.StartFeeder();
        }
    }
}
