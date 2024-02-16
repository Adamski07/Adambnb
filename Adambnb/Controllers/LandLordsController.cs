using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adambnb.Data;
using Adambnb.Models;

namespace Adambnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandLordsController : ControllerBase
    {
        private readonly AdambnbContext _context;

        public LandLordsController(AdambnbContext context)
        {
            _context = context;
        }

        // GET: api/LandLords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandLord>>> GetLandLords()
        {
            return await _context.LandLords.ToListAsync();
        }

        // GET: api/LandLords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LandLord>> GetLandLord(int id)
        {
            var landLord = await _context.LandLords.FindAsync(id);

            if (landLord == null)
            {
                return NotFound();
            }

            return landLord;
        }

        // PUT: api/LandLords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandLord(int id, LandLord landLord)
        {
            if (id != landLord.Id)
            {
                return BadRequest();
            }

            _context.Entry(landLord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandLordExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LandLord>> PostLandLord(LandLord landLord)
        {
            _context.LandLords.Add(landLord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLandLord", new { id = landLord.Id }, landLord);
        }

        // DELETE: api/LandLords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLandLord(int id)
        {
            var landLord = await _context.LandLords.FindAsync(id);
            if (landLord == null)
            {
                return NotFound();
            }

            _context.LandLords.Remove(landLord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LandLordExists(int id)
        {
            return _context.LandLords.Any(e => e.Id == id);
        }
    }
}
