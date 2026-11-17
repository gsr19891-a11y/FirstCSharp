using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;
using System;
using System.Linq;

namespace FitZone.Application.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IWorkoutSessionRepository _sessionRepository;
        private readonly IMemberRepository _memberRepository;

        public BookingService(
            IBookingRepository bookingRepository,
            IWorkoutSessionRepository sessionRepository,
            IMemberRepository memberRepository)
        {
            _bookingRepository = bookingRepository;
            _sessionRepository = sessionRepository;
            _memberRepository = memberRepository;
        }

        public void BookSession(int memberId, int sessionId)
        {
            var member = _memberRepository.GetMemberById(memberId);
            if (member == null)
                throw new Exception("Member not found.");

            var session = _sessionRepository.GetSessionById(sessionId);
            if (session == null || session.Status != "Active")
                throw new Exception("Workout session not found or cancelled.");

            // 1. Check: Are there available slots (Capacity)
            int activeBookingsCount = session.Bookings.Count(b => b.Status == "Active");
            if (activeBookingsCount >= session.Capacity)
            {
                throw new Exception("No available slots left for this session (Capacity is full).");
            }

            // 2. Check: Is the member already booked for this session
            bool alreadyBooked = session.Bookings.Any(b => b.MemberId == memberId && b.Status == "Active");
            if (alreadyBooked)
            {
                throw new Exception("You are already booked for this session.");
            }

            // 3. Check: Time conflicts (overlapping workouts)
            var memberBookings = _bookingRepository.GetBookingsByMemberId(memberId)
                .Where(b => b.Status == "Active")
                .ToList();

            foreach (var booking in memberBookings)
            {
                var existingSession = booking.WorkoutSession;
                var existingStart = existingSession.StartDateTime;
                var existingEnd = existingStart.AddMinutes(existingSession.DurationMinutes);

                var newStart = session.StartDateTime;
                var newEnd = newStart.AddMinutes(session.DurationMinutes);

                // Time overlap formula
                if (newStart < existingEnd && newEnd > existingStart)
                {
                    throw new Exception($"Time conflict: You already have a booking for '{existingSession.Type}' during this time slot ({existingStart:HH:mm} - {existingEnd:HH:mm}).");
                }
            }

            // Create new booking
            var newBooking = new Domain.Models.Entities.Booking
            {
                MemberId = memberId,
                SessionId = sessionId,
                CreatedAt = DateTime.Now,
                Status = "Active"
            };

            _bookingRepository.AddBooking(newBooking);
        }

        public void CancelBooking(int bookingId, int memberId)
        {
            var booking = _bookingRepository.GetBookingById(bookingId);
            if (booking == null)
                throw new Exception("Booking not found.");

            if (booking.MemberId != memberId)
                throw new Exception("You can only cancel your own bookings.");

            if (booking.Status == "Cancelled")
                throw new Exception("This booking is already cancelled.");

            booking.Status = "Cancelled";
            _bookingRepository.UpdateBooking(booking);
        }


        public List<Booking> GetMyBookings(int memberId)
        {
            if (memberId <= 0)
                throw new Exception("Invalid member ID.");

            return _bookingRepository
                .GetBookingsByMemberId(memberId);
        }

    }
}