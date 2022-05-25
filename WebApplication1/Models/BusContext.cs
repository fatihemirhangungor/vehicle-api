using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class BusContext : DbContext
    {
        public BusContext(DbContextOptions<BusContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bus> Buses { get; set; }
    }
}
