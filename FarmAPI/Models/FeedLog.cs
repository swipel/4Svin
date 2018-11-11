using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class FeedLog
    {
        public int FeedLogId { get; set; }
        public int FarmId { get; set; }
        public DateTime Logtime { get; set; }
        public short State { get; set; }

        public Farm Farm { get; set; }
    }
}
