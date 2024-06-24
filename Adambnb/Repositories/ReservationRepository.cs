using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adambnb.Data;
using Adambnb.Models;

namespace Adambnb.Repositories
{
    public class ReservationRepository
    {
        private readonly AdambnbContext _context;

        public ReservationRepository(AdambnbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations(CancellationToken cancellationToken)
        {
            return await _context.Reservations.ToListAsync(cancellationToken);
        }

        public async Task<Reservation> GetReservationById(int id, CancellationToken cancellationToken)
        {
            return await _context.Reservations.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> ReservationExists(int id)
        {
            return await _context.Reservations.AnyAsync(e => e.Id == id);
        }

        public async Task<Reservation> CreateReservation(Reservation reservation, CancellationToken cancellationToken)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(cancellationToken);
            return reservation;
        }

        public async Task<Reservation> UpdateReservation(int id, Reservation reservation, CancellationToken cancellationToken)
        {
            if (id != reservation.Id)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return reservation;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteReservation(int id, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations.FindAsync(new object[] { id }, cancellationToken);
            if (reservation == null)
            {
                return false;
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
