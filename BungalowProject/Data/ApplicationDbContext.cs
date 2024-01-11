using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BungalowProject.Data;

namespace BungalowProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BungalowProject.Data.Reservation>? Reservation { get; set; }
        public DbSet<BungalowProject.Data.Bungalow>? Bungalow { get; set; }
    }
}