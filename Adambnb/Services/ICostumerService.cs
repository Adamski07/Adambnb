using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Adambnb.Models;

namespace Adambnb.Services
{
    public interface ICostumerService
    {
        Task<IEnumerable<Costumer>> GetAllCostumers(CancellationToken cancellationToken);
        Task<Costumer> GetCostumerById(int id, CancellationToken cancellationToken);
        Task AddCostumer(Costumer costumer, CancellationToken cancellationToken);
        Task UpdateCostumer(Costumer costumer, CancellationToken cancellationToken);
        Task DeleteCostumer(int id, CancellationToken cancellationToken);
        bool CostumerExists(int id);
    }
}
