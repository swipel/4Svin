using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class SensorType
    {
        public SensorType()
        {
            Sensor = new HashSet<Sensor>();
        }

        public int SensorTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Sensor> Sensor { get; set; }
    }
}
