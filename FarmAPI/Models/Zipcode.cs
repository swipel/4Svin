using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Zipcode
    {
        public Zipcode()
        {
            Farm = new HashSet<Farm>();
        }

        public int Zipcode1 { get; set; }
        public string City { get; set; }

        public ICollection<Farm> Farm { get; set; }
    }
}
