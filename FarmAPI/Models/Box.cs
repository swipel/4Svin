using System;
using System.Collections.Generic;

namespace FarmAPI.Models
{
    public partial class Box
    {
        public Box()
        {
            SensorBox = new HashSet<SensorBox>();
        }

        public int BoxNumber { get; set; }
        public int BarnNumber { get; set; }
        public int FarmId { get; set; }
        public int BoxType { get; set; }
        public int AnimalAmount { get; set; }

        public Barn Barn { get; set; }
        public BoxType BoxTypeNavigation { get; set; }
        public ICollection<SensorBox> SensorBox { get; set; }
    }
}
