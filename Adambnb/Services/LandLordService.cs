using System.Collections.Generic;
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

        public async Task<IEnumerable<LandLord>> GetAllLandLords()
        {
            return await _landLordRepository.GetAllLandLords();
        }

        public async Task<LandLord> GetLandLordById(int id)
        {
            return await _landLordRepository.GetLandLordById(id);
        }

        public async Task AddLandLord(LandLord landLord)
        {
            await _landLordRepository.CreateLandLord(landLord);
        }

        public async Task UpdateLandLord(LandLord landLord)
        {
            await _landLordRepository.UpdateLandLord(landLord.Id, landLord);
        }

        public async Task DeleteLandLord(int id)
        {
            await _landLordRepository.DeleteLandLord(id);
        }

        public bool LandLordExists(int id)
        {
            return _landLordRepository.LandLordExists(id).Result;
        }
    }
}
