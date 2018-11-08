using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Silo
    {
        public Silo()
        {
            FoodLog = new HashSet<FoodLog>();
            Schedule = new HashSet<Schedule>();
            SensorSilo = new HashSet<SensorSilo>();
        }

        public int SiloNumber { get; set; }
        public int FarmId { get; set; }
        public int FoodTypeId { get; set; }
        public double CurrentFoodAmount { get; set; }

        public Farm Farm { get; set; }
        public FoodType FoodType { get; set; }
        public ICollection<FoodLog> FoodLog { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
        public ICollection<SensorSilo> SensorSilo { get; set; }
    }
}
