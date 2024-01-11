using Microsoft.AspNetCore.Identity;

namespace BungalowProject.Data
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Lists = new List<Reservation>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Reservation> Lists { get; set; }
    }

}
