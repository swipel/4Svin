using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class User
    {
        public User()
        {
            UserFarm = new HashSet<UserFarm>();
        }

        public int UserId { get; set; }
        public string Salt { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int SecurityLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public SecurityLevel SecurityLevelNavigation { get; set; }
        public ICollection<UserFarm> UserFarm { get; set; }
    }
}
