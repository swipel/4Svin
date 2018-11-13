namespace FarmAPI.Models
{
    public class BoxUpdate
    {
        public int BoxNumber { get; set; }
        public int BarnNumber { get; set; }
        public int FarmId { get; set; }
        public int BoxType { get; set; }
        public int AnimalAmount { get; set; }
        
        
        public BoxUpdate(int boxNumber, int barnNumber, int farmId, int boxType, int animalAmount)
        {
            BoxNumber = boxNumber;
            BarnNumber = barnNumber;
            FarmId = farmId;
            BoxType = boxType;
            AnimalAmount = animalAmount;
        }
    }
}