using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class BoatContext : DbContext
    {
        public BoatContext(DbContextOptions<BoatContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Boat> Boats { get; set; }
    }
}
