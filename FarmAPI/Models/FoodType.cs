using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class FoodType
    {
        public FoodType()
        {
            FoodMixType = new HashSet<FoodMixType>();
            Silo = new HashSet<Silo>();
        }

        public int FoodTypeId { get; set; }
        public string FoodType1 { get; set; }

        public ICollection<FoodMixType> FoodMixType { get; set; }
        public ICollection<Silo> Silo { get; set; }
    }
}
