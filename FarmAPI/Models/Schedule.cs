using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int SiloNumber { get; set; }
        public int FarmId { get; set; }
        public DateTime ReadTime { get; set; }

        public Farm Farm { get; set; }
        public Silo Silo { get; set; }
    }
}
