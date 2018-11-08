using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Country
    {
        public Country()
        {
            Farm = new HashSet<Farm>();
        }

        public int CountryCode { get; set; }
        public string Name { get; set; }

        public ICollection<Farm> Farm { get; set; }
    }
}
