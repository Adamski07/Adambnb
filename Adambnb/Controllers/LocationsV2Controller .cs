using Adambnb.Data;
using Adambnb.DTOs;
using Adambnb.Repositories;
using Adambnb.Services;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Adambnb.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class Locations2Controller : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public Locations2Controller(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;

        }

        // GET: api/Locations?api-version=2.0
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<LocationV2DTO>>> GetLocations()
        {
            var locations = await _locationService.GetAllLocationsWithImages();
            var locationsV2DTO = _mapper.Map<List<LocationV2DTO>>(locations);

            return Ok(locationsV2DTO);
        }
    }
}