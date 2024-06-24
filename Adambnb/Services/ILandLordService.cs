using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Adambnb.Models;

namespace Adambnb.Services
{
    public interface ILandLordService
    {
        Task<IEnumerable<LandLord>> GetAllLandLords(CancellationToken cancellationToken);
        Task<LandLord> GetLandLordById(int id, CancellationToken cancellationToken);
        Task AddLandLord(LandLord landLord, CancellationToken cancellationToken);
        Task UpdateLandLord(LandLord landLord, CancellationToken cancellationToken);
        Task DeleteLandLord(int id, CancellationToken cancellationToken);
        bool LandLordExists(int id);
    }
}
