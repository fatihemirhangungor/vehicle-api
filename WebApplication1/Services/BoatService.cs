using CarProjectWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class BoatService : IVehicleRepository<Boat>
    {
        private readonly BoatContext _context;

        public BoatService(BoatContext context)
        {
            _context = context;
        }

        public async Task<Boat> Create(Boat boat)
        {
            _context.Boats.Add(boat);
            await _context.SaveChangesAsync();

            return boat;
        }

        public async Task Delete(int id)
        {
            var boatToDelete = await _context.Boats.FindAsync(id);
            _context.Boats.Remove(boatToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Boat>> Get()
        {
            return await _context.Boats.ToListAsync();
        }

        public async Task<Boat> GetByColor(string color)
        {
            return await _context.Boats.SingleOrDefaultAsync(boat => boat.Color == color);
        }

        public async Task<Boat> GetById(int id)
        {
            return await _context.Boats.FindAsync(id);
        }

        public async Task SetHeadLights(int id)
        {
            Boat newBoat = _context.Boats.Find(id);

            if (newBoat.Headlights == true)
            {
                _context.Boats.Find(id).Headlights = false;
            }
            else
            {
                _context.Boats.Find(id).Headlights = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Update(Boat boat)
        {
            _context.Entry(boat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
