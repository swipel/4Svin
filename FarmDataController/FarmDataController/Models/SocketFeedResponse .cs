namespace FarmDataController.Models
{
    public class SocketFeedResponse 
    {
        public int FarmId { get; set; }
        public bool Status { get; set; }
        
            public SocketFeedResponse (int farmId, bool status)
        {
            FarmId = farmId;
            Status = status;
        }
    }
}