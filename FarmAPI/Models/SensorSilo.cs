using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class SensorSilo
    {
        public int SensorId { get; set; }
        public int FarmId { get; set; }
        public int SiloNumber { get; set; }

        public Sensor Sensor { get; set; }
        public Silo Silo { get; set; }
    }
}
