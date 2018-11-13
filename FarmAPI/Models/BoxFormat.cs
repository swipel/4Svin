using System;

namespace FarmAPI.Models
{
    public class BoxFormat
    {
        public int BoxNumber { get; set; }
        public int BarnNumber { get; set; }
        public int FarmId { get; set; }
        public string BoxType { get; set; }
        public int BoxTypeId { get; set; }
        public int AnimalAmount { get; set; }
    }
}
