using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetLocations()
        {
            var locations = await _locationService.GetAllLocationsWithImages();
            var locationsDTO = _mapper.Map<List<LocationDTO>>(locations);

            return Ok(locationsDTO);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _locationService.GetLocationById(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            try
            {
                await _locationService.UpdateLocation(location);
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
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            await _locationService.AddLocation(location);
            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }

            await _locationService.DeleteLocation(id);
            return NoContent();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocations();
            return Ok(locations);
        }

        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> SearchLocations([FromBody] LocationSearchDto searchDto)
        {
            var locations = await _locationService.SearchLocations(searchDto);
            var locationsDTO = _mapper.Map<List<LocationV2DTO>>(locations);
            return Ok(locationsDTO);
        }

        [HttpGet("GetMaxPrice")]
        public async Task<ActionResult<int>> GetMaxPrice()
        {
            var maxPrice = await _locationService.GetMaxPrice();
            return Ok(new { Price = maxPrice });
        }

        [HttpGet("GetDetails/{id}")]
        public async Task<ActionResult<LocationDetailsDto>> GetLocationDetails(int id)
        {
            var locationDetails = await _locationService.GetLocationDetails(id);
            if (locationDetails == null)
            {
                return NotFound();
            }
            return Ok(locationDetails);
        }
    }
}
