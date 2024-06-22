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
    public class CostumersController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        public CostumersController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }

        // GET: api/Costumers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costumer>>> GetCostumers()
        {
            var costumers = await _costumerService.GetAllCostumers();
            return Ok(costumers);
        }

        // GET: api/Costumers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Costumer>> GetCostumer(int id)
        {
            var costumer = await _costumerService.GetCostumerById(id);

            if (costumer == null)
            {
                return NotFound();
            }

            return Ok(costumer);
        }

        // PUT: api/Costumers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostumer(int id, Costumer costumer)
        {
            if (id != costumer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _costumerService.UpdateCostumer(costumer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_costumerService.CostumerExists(id))
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

        // POST: api/Costumers
        [HttpPost]
        public async Task<ActionResult<Costumer>> PostCostumer(Costumer costumer)
        {
            await _costumerService.AddCostumer(costumer);
            return CreatedAtAction("GetCostumer", new { id = costumer.Id }, costumer);
        }

        // DELETE: api/Costumers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostumer(int id)
        {
            var costumer = await _costumerService.GetCostumerById(id);
            if (costumer == null)
            {
                return NotFound();
            }

            await _costumerService.DeleteCostumer(id);
            return NoContent();
        }
    }
}
