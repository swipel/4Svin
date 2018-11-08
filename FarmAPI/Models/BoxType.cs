using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class BoxType
    {
        public BoxType()
        {
            Box = new HashSet<Box>();
            FoodMixType = new HashSet<FoodMixType>();
        }

        public int BoxTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Box> Box { get; set; }
        public ICollection<FoodMixType> FoodMixType { get; set; }
    }
}
