using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Farm
    {
        public Farm()
        {
            Barn = new HashSet<Barn>();
            FeedLog = new HashSet<FeedLog>();
            Schedule = new HashSet<Schedule>();
            Silo = new HashSet<Silo>();
            UserFarm = new HashSet<UserFarm>();
        }

        public int FarmId { get; set; }
        public string FarmName { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }
        public int CountryCode { get; set; }
        public string PhoneNumber { get; set; }

        public Country CountryCodeNavigation { get; set; }
        public Zipcode ZipCodeNavigation { get; set; }
        public ICollection<Barn> Barn { get; set; }
        public ICollection<FeedLog> FeedLog { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
        public ICollection<Silo> Silo { get; set; }
        public ICollection<UserFarm> UserFarm { get; set; }
    }
}
