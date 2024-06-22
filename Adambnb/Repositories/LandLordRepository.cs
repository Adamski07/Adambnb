using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adambnb.Data;
using Adambnb.Models;

namespace Adambnb.Repositories
{
    public class LandLordRepository
    {
        private readonly AdambnbContext _context;

        public LandLordRepository(AdambnbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LandLord>> GetAllLandLords()
        {
            return await _context.LandLords.ToListAsync();
        }

        public async Task<LandLord> GetLandLordById(int id)
        {
            return await _context.LandLords.FindAsync(id);
        }

        public async Task<bool> LandLordExists(int id)
        {
            return await _context.LandLords.AnyAsync(e => e.Id == id);
        }

        public async Task<LandLord> CreateLandLord(LandLord landLord)
        {
            _context.LandLords.Add(landLord);
            await _context.SaveChangesAsync();
            return landLord;
        }

        public async Task<LandLord> UpdateLandLord(int id, LandLord landLord)
        {
            if (id != landLord.Id)
            {
                return null;
            }

            _context.Entry(landLord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return landLord;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LandLordExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteLandLord(int id)
        {
            var landLord = await _context.LandLords.FindAsync(id);
            if (landLord == null)
            {
                return false;
            }

            _context.LandLords.Remove(landLord);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
