using System.Collections.Generic;
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

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<bool> ReservationExists(int id)
        {
            return await _context.Reservations.AnyAsync(e => e.Id == id);
        }

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        public async Task<bool> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return false;
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
