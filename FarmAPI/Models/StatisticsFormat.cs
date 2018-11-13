using System;

namespace FarmAPI.Models
{
    public class StatisticsFormat
    {
        public int BoxNumber { get; set; }
        public int BarnNumber { get; set; }
        public int FarmId { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public double SensorValue { get; set; }
        public DateTime LogTime { get; set; }
        
        /*
        public StatisticsFormat(int boxNumber, int barnNumber, int farmId, string type, int typeId, double sensorValue, DateTime logTime )
        {
            BoxNumber = boxNumber;
            BarnNumber = barnNumber;
            FarmId = farmId;
            Type = type;
            TypeId = typeId;
            SensorValue = sensorValue;
            LogTime = logTime;            
        }*/
    }
}