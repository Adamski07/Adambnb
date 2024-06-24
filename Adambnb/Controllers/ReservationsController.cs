using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adambnb.Models;
using Adambnb.Services;
using Adambnb.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Adambnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(CancellationToken cancellationToken)
        {
            var reservations = await _reservationService.GetAllReservations(cancellationToken);
            return Ok(reservations);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetReservationById(id, cancellationToken);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation, CancellationToken cancellationToken)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            try
            {
                await _reservationService.UpdateReservation(reservation, cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_reservationService.ReservationExists(id))
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

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation, CancellationToken cancellationToken)
        {
            await _reservationService.AddReservation(reservation, cancellationToken);
            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetReservationById(id, cancellationToken);
            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationService.DeleteReservation(id, cancellationToken);
            return NoContent();
        }

        // POST: api/Reservations/CreateReservation
        [HttpPost("CreateReservation")]
        public async Task<ActionResult<ReservationResponseDto>> CreateReservation([FromBody] ReservationRequestDto requestDto, CancellationToken cancellationToken)
        {
            var reservationResponse = await _reservationService.CreateReservation(requestDto);
            if (reservationResponse == null)
            {
                return Conflict("The requested dates are no longer available.");
            }
            return Ok(reservationResponse);
        }
    }
}
