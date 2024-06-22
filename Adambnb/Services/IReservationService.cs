using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;

namespace Adambnb.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetReservationById(int id);
        Task AddReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);
        Task DeleteReservation(int id);
        bool ReservationExists(int id);
    }
}
