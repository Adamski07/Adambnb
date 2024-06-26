﻿using System.Collections.Generic;
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
    public class CostumersController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        public CostumersController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }

        // GET: api/Costumers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costumer>>> GetCostumers(CancellationToken cancellationToken)
        {
            var costumers = await _costumerService.GetAllCostumers(cancellationToken);
            return Ok(costumers);
        }

        // GET: api/Costumers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Costumer>> GetCostumer(int id, CancellationToken cancellationToken)
        {
            var costumer = await _costumerService.GetCostumerById(id, cancellationToken);

            if (costumer == null)
            {
                return NotFound();
            }

            return Ok(costumer);
        }

        // PUT: api/Costumers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostumer(int id, Costumer costumer, CancellationToken cancellationToken)
        {
            if (id != costumer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _costumerService.UpdateCostumer(costumer, cancellationToken);
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
        public async Task<ActionResult<Costumer>> PostCostumer(Costumer costumer, CancellationToken cancellationToken)
        {
            await _costumerService.AddCostumer(costumer, cancellationToken);
            return CreatedAtAction("GetCostumer", new { id = costumer.Id }, costumer);
        }

        // DELETE: api/Costumers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostumer(int id, CancellationToken cancellationToken)
        {
            var costumer = await _costumerService.GetCostumerById(id, cancellationToken);
            if (costumer == null)
            {
                return NotFound();
            }

            await _costumerService.DeleteCostumer(id, cancellationToken);
            return NoContent();
        }
    }
}
