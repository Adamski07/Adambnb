using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;
using Adambnb.Repositories;

namespace Adambnb.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationRepository.GetAllReservations();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationRepository.GetReservationById(id);
        }

        public async Task AddReservation(Reservation reservation)
        {
            await _reservationRepository.CreateReservation(reservation);
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await _reservationRepository.UpdateReservation(reservation.Id, reservation);
        }

        public async Task DeleteReservation(int id)
        {
            await _reservationRepository.DeleteReservation(id);
        }

        public bool ReservationExists(int id)
        {
            return _reservationRepository.ReservationExists(id).Result;
        }
    }
}
