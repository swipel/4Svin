using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class SensorBox
    {
        public int SensorId { get; set; }
        public int BoxNumber { get; set; }
        public int BarnNumber { get; set; }
        public int FarmId { get; set; }

        public Box Box { get; set; }
        public Sensor Sensor { get; set; }
    }
}
