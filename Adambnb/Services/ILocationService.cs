using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;
using Adambnb.DTOs;

namespace Adambnb.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<Location> GetLocationById(int id);
        Task AddLocation(Location location);
        Task UpdateLocation(Location location);
        Task DeleteLocation(int id);
        Task<IEnumerable<Location>> GetAllLocationsWithImages();
        bool LocationExists(int id);
        Task<IEnumerable<Location>> SearchLocations(LocationSearchDto searchDto);
        Task<int> GetMaxPrice();
        Task<LocationDetailsDto> GetLocationDetails(int id);
    }
}
