using CarProjectWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class BusService : IVehicleRepository<Bus>
    {
        private readonly BusContext _context;

        public BusService(BusContext context)
        {
            _context = context;
        }

        public async Task<Bus> GetByColor(string color)
        {
            return await _context.Buses.SingleOrDefaultAsync(bus => bus.Color == color);
        }

        public async Task Delete(int id)
        {
            var busToDelete = await _context.Buses.FindAsync(id);
            _context.Buses.Remove(busToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bus>> Get()
        {
            return await _context.Buses.ToListAsync();
        }

        public async Task<Bus> GetById(int id)
        {
            return await _context.Buses.FindAsync(id);
        }

        public async Task<Bus> Create(Bus bus)
        {
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();

            return bus;
        }

        public async Task Update(Bus bus)
        {
            _context.Entry(bus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SetHeadLights(int id)
        {
            Bus newBus = _context.Buses.Find(id);

            if (newBus.Headlights == true)
            {
                _context.Buses.Find(id).Headlights = false;
            }
            else
            {
                _context.Buses.Find(id).Headlights = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
