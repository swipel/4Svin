using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class SecurityLevel
    {
        public SecurityLevel()
        {
            User = new HashSet<User>();
        }

        public int SecurityLevel1 { get; set; }
        public byte Lvl { get; set; }

        public ICollection<User> User { get; set; }
    }
}
