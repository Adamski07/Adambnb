using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adambnb.Data;
using Adambnb.Models;

namespace Adambnb.Repositories
{
    public class CostumerRepository
    {
        private readonly AdambnbContext _context;

        public CostumerRepository(AdambnbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Costumer>> GetAllCostumers()
        {
            return await _context.Costumers.ToListAsync();
        }

        public async Task<Costumer> GetCostumerById(int id)
        {
            return await _context.Costumers.FindAsync(id);
        }

        public async Task<bool> CostumerExists(int id)
        {
            return await _context.Costumers.AnyAsync(e => e.Id == id);
        }

        public async Task<Costumer> CreateCostumer(Costumer costumer)
        {
            _context.Costumers.Add(costumer);
            await _context.SaveChangesAsync();
            return costumer;
        }

        public async Task<Costumer> UpdateCostumer(int id, Costumer costumer)
        {
            if (id != costumer.Id)
            {
                return null;
            }

            _context.Entry(costumer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return costumer;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CostumerExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteCostumer(int id)
        {
            var costumer = await _context.Costumers.FindAsync(id);
            if (costumer == null)
            {
                return false;
            }

            _context.Costumers.Remove(costumer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
