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
    public class BoatController : ControllerBase
    {
        private readonly IVehicleRepository<Boat> _boatService;

        public BoatController(IVehicleRepository<Boat> boatService)
        {
            _boatService = boatService;
        }

        [HttpGet("GetBoatsByColor/{color}")]
        public async Task<ActionResult<Boat>> GetBusesByColor(string color)
        {
            return await _boatService.GetByColor(color);
        }

        [HttpGet("GetAllBoats")]
        public async Task<IEnumerable<Boat>> GetBoats()
        {
            return await _boatService.Get();
        }

        [HttpPost("AddBoat")]
        public async Task<ActionResult<Bus>> PostCars([FromBody] Boat boat)
        {
            var newBoat = await _boatService.Create(boat);
            return CreatedAtAction(nameof(GetBoats), new { id = newBoat.Id }, newBoat);
        }
    }
}
