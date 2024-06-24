using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adambnb.Data;
using Adambnb.Models;
using Adambnb.Repositories;
using Adambnb.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Adambnb.Services
{
    public class LocationService : ILocationService
    {
        private readonly AdambnbContext _context;
        private readonly LocationRepository _locationRepository;

        public LocationService(AdambnbContext context)
        {
            _context = context;
            _locationRepository = new LocationRepository(context);
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _locationRepository.GetAllLocations();
        }

        public async Task<Location> GetLocationById(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task AddLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Location>> GetAllLocationsWithImages()
        {
            return await _locationRepository.GetAllLocationsWithImages();
        }

        public bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }

        private int ConvertFeaturesToInt(List<Location.Features> features)
        {
            var featureValues = new Dictionary<Location.Features, int>
            {
                { Location.Features.Smoking, 1 },
                { Location.Features.PetsAllowed, 2 },
                { Location.Features.Wifi, 4 },
                { Location.Features.Tv, 8 },
                { Location.Features.Bath, 16 },
                { Location.Features.Breakfast, 32 }
            };

            int featuresSum = 0;
            foreach (var feature in features)
            {
                if (featureValues.TryGetValue(feature, out int value))
                {
                    featuresSum += value;
                }
            }
            return featuresSum;
        }

        public async Task<IEnumerable<Location>> SearchLocations(LocationSearchDto searchDto)
        {
            var query = _context.Locations.AsQueryable();

            if (searchDto.Features.HasValue)
            {
                var fetures = query.Where(l => l.Id == 1);
                query = query.Where(l => ConvertFeaturesToInt(l.FeaturesList) == searchDto.Features.Value);
            }
            if (searchDto.Type.HasValue)
            {
                query = query.Where(l => (int)l.Type == searchDto.Type.Value);
            }
            if (searchDto.Rooms.HasValue)
            {
                query = query.Where(l => l.Rooms >= searchDto.Rooms.Value);
            }
            if (searchDto.MinPrice.HasValue)
            {
                query = query.Where(l => l.PricePerDay >= searchDto.MinPrice.Value);
            }
            if (searchDto.MaxPrice.HasValue)
            {
                query = query.Where(l => l.PricePerDay <= searchDto.MaxPrice.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<int> GetMaxPrice()
        {
            return await _context.Locations.MaxAsync(l => (int)l.PricePerDay);
        }

        public async Task<LocationDetailsDto> GetLocationDetails(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Images)
                .Include(l => l.LandLord)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                return null;
            }

            return new LocationDetailsDto
            {
                Title = location.Title,
                SubTitle = location.Subtitle,
                Description = location.Description,
                Rooms = location.Rooms,
                NumberOfGuests = location.NumberOfGuests,
                PricePerDay = location.PricePerDay,
                Type = (int)location.Type,
                Features = ConvertFeaturesToInt(location.FeaturesList),
                Images = location.Images.Select(img => new ImageDto
                {
                    URL = img.Url,
                    IsCover = img.IsCover
                }).ToList(),
                Landlord = new LandlordDto
                {
                    Name = location.LandLord.FirstName,
                    Avatar = location.LandLord.Avatar?.Url
                }
            };
        }

        public async Task<IEnumerable<DateTime>> GetUnavailableDates(int locationId)
        {
            var reservations = await _context.Reservations
                .Where(r => r.LocationId == locationId)
                .Select(r => new { r.StartDate, r.EndDate })
                .ToListAsync();

            var unavailableDates = new List<DateTime>();
            foreach (var reservation in reservations)
            {
                for (var date = reservation.StartDate; date <= reservation.EndDate; date = date.AddDays(1))
                {
                    unavailableDates.Add(date);
                }
            }
            return unavailableDates;
        }
    }
}
