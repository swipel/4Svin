using System.Drawing;

namespace FarmAPI.Models
{
    public enum TypeEnum {Feed, Statistics}

    public class SocketMessage
    {
       // public int Type { get; set; }
        public TypeEnum Type { get; set; }
        public int BoxId { get; set; }
        public int BarnId { get; set; }
        public int FarmId { get; set; }
        
        /*Type
        1 = Feed
        2 = Statistics
        */
        //Er ikke sikker på det her er den bedste måde :/
        
        
        public SocketMessage(TypeEnum type, int farmId)
        {
            Type = type;
            FarmId = farmId;
        }

        public SocketMessage(TypeEnum type, int boxId, int barnId, int farmId)
        {
            Type = type;
            BoxId = boxId;
            BarnId = barnId;
            FarmId = farmId;
        }
    }
}