using System.Collections.Generic;
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

        public async Task<IEnumerable<Costumer>> GetAllCostumers()
        {
            return await _costumerRepository.GetAllCostumers();
        }

        public async Task<Costumer> GetCostumerById(int id)
        {
            return await _costumerRepository.GetCostumerById(id);
        }

        public async Task AddCostumer(Costumer costumer)
        {
            await _costumerRepository.CreateCostumer(costumer);
        }

        public async Task UpdateCostumer(Costumer costumer)
        {
            await _costumerRepository.UpdateCostumer(costumer.Id, costumer);
        }

        public async Task DeleteCostumer(int id)
        {
            await _costumerRepository.DeleteCostumer(id);
        }

        public bool CostumerExists(int id)
        {
            return _costumerRepository.CostumerExists(id).Result;
        }
    }
}
