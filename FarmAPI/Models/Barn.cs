using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Barn
    {
        public Barn()
        {
            Box = new HashSet<Box>();
        }

        public int BarnNumber { get; set; }
        public int FarmId { get; set; }

        public Farm Farm { get; set; }
        public ICollection<Box> Box { get; set; }
    }
}
