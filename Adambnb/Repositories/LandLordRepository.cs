using System.Collections.Generic;
using System.Threading;
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

        public async Task<IEnumerable<LandLord>> GetAllLandLords(CancellationToken cancellationToken)
        {
            return await _context.LandLords.ToListAsync(cancellationToken);
        }

        public async Task<LandLord> GetLandLordById(int id, CancellationToken cancellationToken)
        {
            return await _context.LandLords.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> LandLordExists(int id)
        {
            return await _context.LandLords.AnyAsync(e => e.Id == id);
        }

        public async Task<LandLord> CreateLandLord(LandLord landLord, CancellationToken cancellationToken)
        {
            _context.LandLords.Add(landLord);
            await _context.SaveChangesAsync(cancellationToken);
            return landLord;
        }

        public async Task<LandLord> UpdateLandLord(int id, LandLord landLord, CancellationToken cancellationToken)
        {
            if (id != landLord.Id)
            {
                return null;
            }

            _context.Entry(landLord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
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

        public async Task<bool> DeleteLandLord(int id, CancellationToken cancellationToken)
        {
            var landLord = await _context.LandLords.FindAsync(new object[] { id }, cancellationToken);
            if (landLord == null)
            {
                return false;
            }

            _context.LandLords.Remove(landLord);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
