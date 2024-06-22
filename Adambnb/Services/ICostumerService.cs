using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;

namespace Adambnb.Services
{
    public interface ICostumerService
    {
        Task<IEnumerable<Costumer>> GetAllCostumers();
        Task<Costumer> GetCostumerById(int id);
        Task AddCostumer(Costumer costumer);
        Task UpdateCostumer(Costumer costumer);
        Task DeleteCostumer(int id);
        bool CostumerExists(int id);
    }
}
