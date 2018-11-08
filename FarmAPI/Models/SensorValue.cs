using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class SensorValue
    {
        public int SensorValueId { get; set; }
        public int SensorId { get; set; }
        public DateTime LogTime { get; set; }
        public double Value { get; set; }

        public Sensor Sensor { get; set; }
    }
}
