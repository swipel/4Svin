using FarmDataController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FarmDataController.Sockets
{
    public class MCSensorSocket
    {
        public MCSensorSocket()
        {
            Ip = Dns.GetHostEntry("10.108.137.203").AddressList[2];
            Server = new TcpListener(Ip, 80);
            Client = default(TcpClient);
            Server.Start();
            Client = Server.AcceptTcpClient();
            Client.GetStream();
            IncommingData = new byte[10];
            Stream.Read(IncommingData, 0, IncommingData.Length);
            string dataToRead = Encoding.ASCII.GetString(IncommingData, 0, IncommingData.Length);

            Thread updateSensorList = new Thread(CreateSensorObject);
            updateSensorList.Start();

            

        }

        public void testmet()
        { }

        private IPAddress Ip { get; set; }
        private TcpListener Server { get; set; }
        private TcpClient Client { get; set; }
        private NetworkStream Stream { get; set; }
        private Byte[] IncommingData { get; set; }
        private List<Sensor> Sensors { get; set; }

        public List<Sensor> GatherAndShipSensors()
        {
            lock(Sensors)
            {
                return Sensors;

            }
        }
        
        private void CreateSensorObject()
        {
            while (true)
            {
                lock (Sensors)
                {
                    Sensors.Clear();

                    //byte to object conversion on Byte[] stream

                    Sensors.Add(new WaterSensor() { Measurement = "liter", Value = 2f });
                    Sensors.Add(new FoodSensor() { Measurement = "kg", Value = 2f });
                    Sensors.Add(new UvSensor() { Measurement = "UV", Value = 2f });
                    Sensors.Add(new TemperatureSensor() { Measurement = "celcius", Value = 2f });
                }
                Thread.Sleep(30000);
                
            }
            
        }
    }
}
