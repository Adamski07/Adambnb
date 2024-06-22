using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;

namespace Adambnb.Services
{
    public interface ILandLordService
    {
        Task<IEnumerable<LandLord>> GetAllLandLords();
        Task<LandLord> GetLandLordById(int id);
        Task AddLandLord(LandLord landLord);
        Task UpdateLandLord(LandLord landLord);
        Task DeleteLandLord(int id);
        bool LandLordExists(int id);
    }
}
