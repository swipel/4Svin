using FarmDataController.Enum;

namespace FarmDataController.Models
{
    
    public class SocketReceive
    {
        public TypeEnum Type { get; set; }
        public int SensorId { get; set; }
        public int FarmId { get; set; }
        
        public SocketReceive(TypeEnum type, int sensorId, int farmId)
        {
            SensorId = sensorId;
            Type = type;
            FarmId = farmId;
        }
    }
}