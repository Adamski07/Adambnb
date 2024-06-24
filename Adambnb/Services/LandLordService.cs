using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Adambnb.Models;
using Adambnb.Repositories;

namespace Adambnb.Services
{
    public class LandLordService : ILandLordService
    {
        private readonly LandLordRepository _landLordRepository;

        public LandLordService(LandLordRepository landLordRepository)
        {
            _landLordRepository = landLordRepository;
        }

        public async Task<IEnumerable<LandLord>> GetAllLandLords(CancellationToken cancellationToken)
        {
            return await _landLordRepository.GetAllLandLords(cancellationToken);
        }

        public async Task<LandLord> GetLandLordById(int id, CancellationToken cancellationToken)
        {
            return await _landLordRepository.GetLandLordById(id, cancellationToken);
        }

        public async Task AddLandLord(LandLord landLord, CancellationToken cancellationToken)
        {
            await _landLordRepository.CreateLandLord(landLord, cancellationToken);
        }

        public async Task UpdateLandLord(LandLord landLord, CancellationToken cancellationToken)
        {
            await _landLordRepository.UpdateLandLord(landLord.Id, landLord, cancellationToken);
        }

        public async Task DeleteLandLord(int id, CancellationToken cancellationToken)
        {
            await _landLordRepository.DeleteLandLord(id, cancellationToken);
        }

        public bool LandLordExists(int id)
        {
            return _landLordRepository.LandLordExists(id).Result;
        }
    }
}
