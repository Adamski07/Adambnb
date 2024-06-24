using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Adambnb.Models;
using Adambnb.DTOs;

namespace Adambnb.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken);
        Task<Location> GetLocationById(int id, CancellationToken cancellationToken);
        Task AddLocation(Location location, CancellationToken cancellationToken);
        Task UpdateLocation(Location location, CancellationToken cancellationToken);
        Task DeleteLocation(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Location>> GetAllLocationsWithImages(CancellationToken cancellationToken);
        bool LocationExists(int id);
        Task<IEnumerable<Location>> SearchLocations(LocationSearchDto searchDto, CancellationToken cancellationToken);
        Task<int> GetMaxPrice(CancellationToken cancellationToken);
        Task<LocationDetailsDto> GetLocationDetails(int id, CancellationToken cancellationToken);
        Task<IEnumerable<DateTime>> GetUnavailableDates(int locationId, CancellationToken cancellationToken);
    }
}
