﻿using System.Collections.Generic;
using System.Linq;
using TurfBooking.Model;


namespace TurfBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly TurfBookingContext _context;

        public BookingService(TurfBookingContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBooking(int id)
        {
            return _context.Bookings.Find(id);
        }

        public void AddBooking(Booking booking)
        {
            var newbooking = new Booking
            {
                BookingDate = booking.BookingDate,
                Duration = booking.Duration,
                TurfId = booking.TurfId,
                UserId = booking.UserId
            };

            _context.Bookings.Add(newbooking);
            _context.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}