namespace TurfBooking.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }  
        public int Duration { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }
        public int TurfId { get; set; }
        //public Turf Turf { get; set; }

    }
}
