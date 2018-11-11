using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class UserFarm
    {
        public int UserId { get; set; }
        public int FarmId { get; set; }

        public Farm Farm { get; set; }
        public User User { get; set; }
    }
}
