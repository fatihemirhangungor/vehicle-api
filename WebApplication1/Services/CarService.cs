using CarProjectWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Repositories;

namespace CarProjectWebApi.Services
{
    public class CarService : IVehicleRepository<Car>
    {
        private readonly CarContext _context;

        public CarService(CarContext context)
        {
            _context = context;
        }
        public async Task<Car> Create(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task Delete(int id)
        {
            var carToDelete = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(carToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> Get()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByColor(string color)
        {
            return await _context.Cars.SingleOrDefaultAsync(car => car.Color == color);
        }

        public async Task Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SetHeadLights(int id)
        {
            Car newCar = _context.Cars.Find(id);

            if (newCar.Headlights == true)
            {
                _context.Cars.Find(id).Headlights = false;
            }
            else
            {
                _context.Cars.Find(id).Headlights = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetById(int id)
        {
            return await _context.Cars.FindAsync(id);
        }
    }
}
