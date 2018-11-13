using FarmDataController.Models;
using FarmDataController.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDataController.Managers
{
    public sealed class MCManager
    {
        private static MCManager instance = null;
        private static readonly object padlock = new object();

        MCManager(){}

        public static MCManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MCManager();
                    }
                    return instance;
                }
            }
        }
        
        //MCSensorSocket SensorSocket = new MCSensorSocket();
        List<Sensor> Sensorlist = new List<Sensor>();


        public List<Sensor> GetSocketData()
        {
            List<Sensor> _Sensorlist = new List<Sensor>();
           // Sensorlist = SensorSocket.GatherAndShipSensors();
            return Sensorlist;
        }

        public SocketFeedResponse SocketFeed(int farmId)
        {
            MCFeederSocket feederSocket = new MCFeederSocket();
            var response = feederSocket.FeederFeed();
            return new SocketFeedResponse(farmId, response);
        }
    }
}
