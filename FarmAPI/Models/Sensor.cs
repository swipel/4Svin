using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Sensor
    {
        public Sensor()
        {
            SensorBox = new HashSet<SensorBox>();
            SensorSilo = new HashSet<SensorSilo>();
            SensorValue = new HashSet<SensorValue>();
        }

        public int SensorId { get; set; }
        public int SensorTypeId { get; set; }
        public int Interval { get; set; }

        public SensorType SensorType { get; set; }
        public ICollection<SensorBox> SensorBox { get; set; }
        public ICollection<SensorSilo> SensorSilo { get; set; }
        public ICollection<SensorValue> SensorValue { get; set; }
    }
}
