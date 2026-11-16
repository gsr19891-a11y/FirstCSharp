namespace FitZone.Application.Services.Interfaces
{
    public interface IBookingService
    {
        void BookSession(int memberId, int sessionId);
        void CancelBooking(int bookingId, int memberId);
    }
}