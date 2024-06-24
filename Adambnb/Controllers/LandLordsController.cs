using System.Collections.Generic;
using System.Threading;
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
        public async Task<ActionResult<IEnumerable<LandLord>>> GetLandLords(CancellationToken cancellationToken)
        {
            var landLords = await _landLordService.GetAllLandLords(cancellationToken);
            return Ok(landLords);
        }

        // GET: api/LandLords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LandLord>> GetLandLord(int id, CancellationToken cancellationToken)
        {
            var landLord = await _landLordService.GetLandLordById(id, cancellationToken);

            if (landLord == null)
            {
                return NotFound();
            }

            return Ok(landLord);
        }

        // PUT: api/LandLords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandLord(int id, LandLord landLord, CancellationToken cancellationToken)
        {
            if (id != landLord.Id)
            {
                return BadRequest();
            }

            try
            {
                await _landLordService.UpdateLandLord(landLord, cancellationToken);
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
        public async Task<ActionResult<LandLord>> PostLandLord(LandLord landLord, CancellationToken cancellationToken)
        {
            await _landLordService.AddLandLord(landLord, cancellationToken);
            return CreatedAtAction("GetLandLord", new { id = landLord.Id }, landLord);
        }

        // DELETE: api/LandLords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLandLord(int id, CancellationToken cancellationToken)
        {
            var landLord = await _landLordService.GetLandLordById(id, cancellationToken);
            if (landLord == null)
            {
                return NotFound();
            }

            await _landLordService.DeleteLandLord(id, cancellationToken);
            return NoContent();
        }
    }
}
