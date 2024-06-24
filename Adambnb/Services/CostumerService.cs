using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Adambnb.Models;
using Adambnb.Repositories;

namespace Adambnb.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly CostumerRepository _costumerRepository;

        public CostumerService(CostumerRepository costumerRepository)
        {
            _costumerRepository = costumerRepository;
        }

        public async Task<IEnumerable<Costumer>> GetAllCostumers(CancellationToken cancellationToken)
        {
            return await _costumerRepository.GetAllCostumers(cancellationToken);
        }

        public async Task<Costumer> GetCostumerById(int id, CancellationToken cancellationToken)
        {
            return await _costumerRepository.GetCostumerById(id, cancellationToken);
        }

        public async Task AddCostumer(Costumer costumer, CancellationToken cancellationToken)
        {
            await _costumerRepository.CreateCostumer(costumer, cancellationToken);
        }

        public async Task UpdateCostumer(Costumer costumer, CancellationToken cancellationToken)
        {
            await _costumerRepository.UpdateCostumer(costumer.Id, costumer, cancellationToken);
        }

        public async Task DeleteCostumer(int id, CancellationToken cancellationToken)
        {
            await _costumerRepository.DeleteCostumer(id, cancellationToken);
        }

        public bool CostumerExists(int id)
        {
            return _costumerRepository.CostumerExists(id).Result;
        }
    }
}
