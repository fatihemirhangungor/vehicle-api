using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IVehicleRepository<Bus> _busService;

        public BusController(IVehicleRepository<Bus> busService)
        {
            _busService = busService;
        }

        [HttpGet("GetBusesByColor/{color}")]
        public async Task<ActionResult<Bus>> GetBusesByColor(string color)
        {
            return await _busService.GetByColor(color);
        }

        [HttpGet("GetAllBuses")]
        public async Task<IEnumerable<Bus>> GetBuses()
        {
            return await _busService.Get();
        }

        [HttpPost("AddBus")]
        public async Task<ActionResult<Bus>> PostCars([FromBody] Bus bus)
        {
            var newBus = await _busService.Create(bus);
            return CreatedAtAction(nameof(GetBuses), new { id = newBus.Id }, newBus);
        }
    }
}
