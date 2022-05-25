using CarProjectWebApi.Models;
using CarProjectWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Repositories;

namespace CarProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IVehicleRepository<Car> _carService;
        public CarController(IVehicleRepository<Car> carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAllCars")]
        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _carService.Get();
        }
        [HttpGet("GetCarsByColor/{color}")]
        public async Task<ActionResult<Car>> GetCarsByColor(string color)
        {
            return await _carService.GetByColor(color);
        }

        [HttpPost("AddCar")]
        public async Task<ActionResult<Car>> PostCars([FromBody] Car car)
        {
            var newCar = await _carService.Create(car);
            return CreatedAtAction(nameof(GetCars), new { id = newCar.Id }, newCar);
        }

        [HttpPut("SetHeadLightsById/{id}")]
        public async Task<ActionResult> PutCars(int id)
        {   
            await _carService.SetHeadLights(id);

            return NoContent();
        }

        [HttpDelete("DeleteCarById/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var carToDelete = await _carService.GetById(id);
            if (carToDelete == null)
            {
                return NotFound();
            }
            await _carService.Delete(carToDelete.Id);
            return NoContent();
        }
     }
}
