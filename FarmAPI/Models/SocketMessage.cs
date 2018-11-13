using System.Drawing;

namespace FarmAPI.Models
{
    public enum TypeEnum {Feed, Statistics}

    public class SocketMessage
    {
        public TypeEnum Type { get; set; }
        public int FarmId { get; set; }
        public int SensorId { get; set; }
        
        /*Type
        1 = Feed
        2 = Statistics
        */
        
        
        public SocketMessage(TypeEnum type, int farmId)
        {
            Type = type;
            FarmId = farmId;
        }

        public SocketMessage(TypeEnum type, int farmId, int sensorId)
        {
            Type = type;
            SensorId = sensorId;
            FarmId = farmId;
        }
    }
}