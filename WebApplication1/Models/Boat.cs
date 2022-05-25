using WebApplication1.Core;

namespace WebApplication1.Models
{
    public class Boat : IVehicle
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public bool Headlights { get; set; }
    }
}
