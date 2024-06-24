using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adambnb.Data;
using Adambnb.Models;

namespace Adambnb.Repositories
{
    public class LocationRepository
    {
        private readonly AdambnbContext _context;

        public LocationRepository(AdambnbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken)
        {
            return await _context.Locations.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Location>> GetAllLocationsWithImages(CancellationToken cancellationToken)
        {
            return await _context.Locations.Include(l => l.Images).ToListAsync(cancellationToken);
        }

        public async Task<Location> GetLocationById(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<bool> LocationExists(int id)
        {
            return await _context.Locations.AnyAsync(e => e.Id == id);
        }

        public async Task<Location> CreateLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> UpdateLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return null;
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return location;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return false;
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
