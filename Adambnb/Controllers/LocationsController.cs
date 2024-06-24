using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adambnb.Models;
using Adambnb.Services;
using Adambnb.DTOs;
using AutoMapper;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;

namespace Adambnb.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationV2DTO>>> GetLocations(CancellationToken cancellationToken)
        {
            var locations = await _locationService.GetAllLocationsWithImages(cancellationToken);
            /// I use the V2 DTO because the V1 DTO does load the images after recent updates
            var locationsDTO = _mapper.Map<List<LocationV2DTO>>(locations);

            return Ok(locationsDTO);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id, CancellationToken cancellationToken)
        {
            var location = await _locationService.GetLocationById(id, cancellationToken);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location, CancellationToken cancellationToken)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            try
            {
                await _locationService.UpdateLocation(location, cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_locationService.LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location, CancellationToken cancellationToken)
        {
            await _locationService.AddLocation(location, cancellationToken);
            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id, CancellationToken cancellationToken)
        {
            var location = await _locationService.GetLocationById(id, cancellationToken);
            if (location == null)
            {
                return NotFound();
            }

            await _locationService.DeleteLocation(id, cancellationToken);
            return NoContent();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations(CancellationToken cancellationToken)
        {
            var locations = await _locationService.GetAllLocations(cancellationToken);
            return Ok(locations);
        }

        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<LocationV2DTO>>> SearchLocations([FromBody] LocationSearchDto searchDto, CancellationToken cancellationToken)
        {
            var locations = await _locationService.SearchLocations(searchDto, cancellationToken);
            var locationsDTO = _mapper.Map<List<LocationV2DTO>>(locations);
            return Ok(locationsDTO);
        }

        [HttpGet("GetMaxPrice")]
        public async Task<ActionResult<int>> GetMaxPrice(CancellationToken cancellationToken)
        {
            var maxPrice = await _locationService.GetMaxPrice(cancellationToken);
            return Ok(new { Price = maxPrice });
        }

        [HttpGet("GetDetails/{id}")]
        public async Task<ActionResult<LocationDetailsDto>> GetLocationDetails(int id, CancellationToken cancellationToken)
        {
            var locationDetails = await _locationService.GetLocationDetails(id, cancellationToken);
            if (locationDetails == null)
            {
                return NotFound();
            }
            return Ok(locationDetails);
        }

        [HttpGet("UnAvailableDates/{locationId}")]
        public async Task<ActionResult<UnavailableDatesDto>> GetUnavailableDates(int locationId, CancellationToken cancellationToken)
        {
            var unavailableDates = await _locationService.GetUnavailableDates(locationId, cancellationToken);
            if (unavailableDates == null)
            {
                return NotFound();
            }
            return Ok(new UnavailableDatesDto { UnAvailableDates = unavailableDates });
        }
    }
}
