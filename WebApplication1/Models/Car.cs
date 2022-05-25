using WebApplication1.Core;

namespace CarProjectWebApi.Models
{
    public class Car : IVehicle
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public int Wheels { get; set; }
        public bool Headlights { get; set; }
    }
}
