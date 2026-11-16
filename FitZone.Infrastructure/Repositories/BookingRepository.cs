using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;
using FitZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FitZone.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FitZoneDbContext _context;

        public BookingRepository(FitZoneDbContext context)
        {
            _context = context;
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings
                .Include(b => b.WorkoutSession)
                .Include(b => b.Member)
                .FirstOrDefault(b => b.Id == id);
        }

        public List<Booking> GetBookingsByMemberId(int memberId)
        {
            return _context.Bookings
                .Include(b => b.WorkoutSession)
                .Where(b => b.MemberId == memberId)
                .ToList();
        }
    }
}