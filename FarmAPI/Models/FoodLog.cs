using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class FoodLog
    {
        public int FoodLogId { get; set; }
        public int SiloNumber { get; set; }
        public int FarmId { get; set; }
        public double FoodAmount { get; set; }
        public DateTime LogTime { get; set; }

        public Silo Silo { get; set; }
    }
}
