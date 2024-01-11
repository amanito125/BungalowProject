using System.ComponentModel.DataAnnotations;

namespace BungalowProject.Data
{
    public class Reservation
    {
        public Reservation()
        {
            Bungalows = new List<Bungalow>();
        }
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string Description { get; set; }

        public virtual List<Bungalow> Bungalows { get; set; }
        public int BungalowId { get; set; }
        public virtual Bungalow? Bungalow { get; set; }

    }
}