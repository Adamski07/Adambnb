using System.Collections.Generic;
using System.Threading;
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

        public async Task<IEnumerable<Costumer>> GetAllCostumers(CancellationToken cancellationToken)
        {
            return await _context.Costumers.ToListAsync(cancellationToken);
        }

        public async Task<Costumer> GetCostumerById(int id, CancellationToken cancellationToken)
        {
            return await _context.Costumers.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> CostumerExists(int id)
        {
            return await _context.Costumers.AnyAsync(e => e.Id == id);
        }

        public async Task<Costumer> CreateCostumer(Costumer costumer, CancellationToken cancellationToken)
        {
            _context.Costumers.Add(costumer);
            await _context.SaveChangesAsync(cancellationToken);
            return costumer;
        }

        public async Task<Costumer> UpdateCostumer(int id, Costumer costumer, CancellationToken cancellationToken)
        {
            if (id != costumer.Id)
            {
                return null;
            }

            _context.Entry(costumer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
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

        public async Task<bool> DeleteCostumer(int id, CancellationToken cancellationToken)
        {
            var costumer = await _context.Costumers.FindAsync(new object[] { id }, cancellationToken);
            if (costumer == null)
            {
                return false;
            }

            _context.Costumers.Remove(costumer);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
