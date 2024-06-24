using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Adambnb.Models;
using Adambnb.DTOs;

namespace Adambnb.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservations(CancellationToken cancellationToken);
        Task<Reservation> GetReservationById(int id, CancellationToken cancellationToken);
        Task AddReservation(Reservation reservation, CancellationToken cancellationToken);
        Task UpdateReservation(Reservation reservation, CancellationToken cancellationToken);
        Task DeleteReservation(int id, CancellationToken cancellationToken);
        bool ReservationExists(int id);
        Task<ReservationResponseDto> CreateReservation(ReservationRequestDto requestDto);
    }
}
