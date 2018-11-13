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
        //SingleTon
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
        
        List<Sensor> Sensorlist = new List<Sensor>();


        public List<Sensor> GetSocketData()
        {
            List<Sensor> _Sensorlist = new List<Sensor>();
            //TODO Get all sensors
            return Sensorlist;
        }

        //Call socket where feeder is
        public SocketFeedResponse SocketFeed(int farmId)
        {
            MCFeederSocket feederSocket = new MCFeederSocket();
            var response = feederSocket.FeederFeed();
            return new SocketFeedResponse(farmId, response);
        }
    }
}
