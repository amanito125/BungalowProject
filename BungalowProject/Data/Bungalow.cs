using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace BungalowProject.Data
{
    public class Bungalow
    {
        public int Id { get; set; }
        public int BungalowId { get; set; }
        public int Capacity { get; set; }
        public bool IsSmokingAllowed { get; set; }
        public bool IsAvalive { get; set; }
        public bool AllowsPets { get; set; }
        public string Location { get; set; }
        public decimal PricePerNight { get; set; }
        

    }
}
