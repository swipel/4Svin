using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDataController.Models
{
    public abstract class Sensor
    {
        public Sensor()
        {

        }

        public float Value { get; set; }
        public string Measurement { get; set; }
    }
}
