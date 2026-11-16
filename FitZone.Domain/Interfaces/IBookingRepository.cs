using FitZone.Domain.Models.Entities;
using System.Collections.Generic;

namespace FitZone.Domain.Interfaces
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        Booking GetBookingById(int id);
        List<Booking> GetBookingsByMemberId(int memberId);
    }
}