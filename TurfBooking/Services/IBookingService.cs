using System.Collections.Generic;
using TurfBooking.Model;

namespace TurfBooking.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
    }
}