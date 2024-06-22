using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adambnb.Models;
using Adambnb.Services;
using Microsoft.EntityFrameworkCore;

namespace Adambnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandLordsController : ControllerBase
    {
        private readonly ILandLordService _landLordService;

        public LandLordsController(ILandLordService landLordService)
        {
            _landLordService = landLordService;
        }

        // GET: api/LandLords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandLord>>> GetLandLords()
        {
            var landLords = await _landLordService.GetAllLandLords();
            return Ok(landLords);
        }

        // GET: api/LandLords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LandLord>> GetLandLord(int id)
        {
            var landLord = await _landLordService.GetLandLordById(id);

            if (landLord == null)
            {
                return NotFound();
            }

            return Ok(landLord);
        }

        // PUT: api/LandLords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandLord(int id, LandLord landLord)
        {
            if (id != landLord.Id)
            {
                return BadRequest();
            }

            try
            {
                await _landLordService.UpdateLandLord(landLord);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_landLordService.LandLordExists(id))
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

        // POST: api/LandLords
        [HttpPost]
        public async Task<ActionResult<LandLord>> PostLandLord(LandLord landLord)
        {
            await _landLordService.AddLandLord(landLord);
            return CreatedAtAction("GetLandLord", new { id = landLord.Id }, landLord);
        }

        // DELETE: api/LandLords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLandLord(int id)
        {
            var landLord = await _landLordService.GetLandLordById(id);
            if (landLord == null)
            {
                return NotFound();
            }

            await _landLordService.DeleteLandLord(id);
            return NoContent();
        }
    }
}
