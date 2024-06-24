using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;
using Adambnb.Repositories;
using Adambnb.DTOs;
using Microsoft.EntityFrameworkCore;
using Adambnb.Data;

namespace Adambnb.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationRepository _reservationRepository;
        private readonly AdambnbContext _context;


        public ReservationService(ReservationRepository reservationRepository, AdambnbContext context)
        {
            _reservationRepository = reservationRepository;
            _context = context;
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

        public async Task<ReservationResponseDto> CreateReservation(ReservationRequestDto requestDto)
        {
            // Check availability
            var unavailableDates = await _context.Reservations
                .Where(r => r.LocationId == requestDto.LocationId &&
                            ((r.StartDate <= requestDto.StartDate && r.EndDate >= requestDto.StartDate) ||
                             (r.StartDate <= requestDto.EndDate && r.EndDate >= requestDto.EndDate)))
                .ToListAsync();

            if (unavailableDates.Any())
            {
                return null;
            }

            // Find or create customer
            var customer = await _context.Costumers.FirstOrDefaultAsync(c => c.Email == requestDto.Email);
            if (customer == null)
            {
                customer = new Costumer
                {
                    Email = requestDto.Email,
                    FirstName = requestDto.FirstName,
                    LastName = requestDto.LastName
                };
                _context.Costumers.Add(customer);
                await _context.SaveChangesAsync();
            }

            // Create reservation
            var reservation = new Reservation
            {
                StartDate = requestDto.StartDate,
                EndDate = requestDto.EndDate,
                LocationId = requestDto.LocationId,
                CostumerId = customer.Id,
                Discount = requestDto.Discount ?? 0
            };
            await _reservationRepository.CreateReservation(reservation);

            // Calculate price and other details
            var location = await _context.Locations.FindAsync(requestDto.LocationId);
            var totalDays = (requestDto.EndDate - requestDto.StartDate).Days + 1;
            var price = totalDays * location.PricePerDay;
            if (requestDto.Discount.HasValue)
            {
                price -= price * requestDto.Discount.Value / 100;
            }

            return new ReservationResponseDto
            {
                LocationName = location.Title,
                CustomerName = $"{customer.FirstName} {customer.LastName}",
                Price = price,
                Discount = requestDto.Discount ?? 0
            };
        }
    }
}
