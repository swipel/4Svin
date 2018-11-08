using FarmDataController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FarmDataController.Interfaces
{
    public interface ISocket
    {
        IPAddress Ip { get; set; }
        TcpListener Server { get; set; }
        TcpClient Client { get; set; }
        NetworkStream Stream { get; set; }
        Byte[] IncommingData { get; set; }
        List<Sensor> Sensors { get; set; }
    }
}
