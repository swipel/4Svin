using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class FoodMixType
    {
        public int FoodMixTypeId { get; set; }
        public int FoodTypeId { get; set; }
        public int BoxTypeId { get; set; }
        public double Procent { get; set; }

        public BoxType BoxType { get; set; }
        public FoodType FoodType { get; set; }
    }
}
