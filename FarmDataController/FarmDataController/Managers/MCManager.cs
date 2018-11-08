using FarmDataController.Models;
using FarmDataController.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDataController.Managers
{
    public class MCManager
    {
        MCSensorSocket SensorSocket = new MCSensorSocket();

        List<Sensor> Sensorlist = new List<Sensor>();


        public List<Sensor> GetSocketData()
        {
            List<Sensor> _Sensorlist = new List<Sensor>();
            Sensorlist = SensorSocket.GatherAndShipSensors();
            return Sensorlist;
        }

        public bool SocketFeed()
        {
            MCFeederSocket FeederSocket = new MCFeederSocket();
            return true;
        }
    }
}
