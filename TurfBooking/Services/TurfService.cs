using Microsoft.EntityFrameworkCore;
using TurfBooking.Model;

namespace TurfBooking.Services
{
    public class TurfService : ITurfService
    {
        private readonly TurfBookingContext _context;

        public TurfService(TurfBookingContext context)
        {
            _context = context;
        }

        public IEnumerable<Turf> GetTurfs()
        {
            return _context.Turfs.ToList();
        }

        public Turf GetTurf(int id)
        {
            return _context.Turfs.Find(id);
        }

        public void AddTurf(Turf turf)
        {
            var newturf = new Turf
            {
                Availability = turf.Availability,
                Location = turf.Location,
                Name = turf.Name

            };
            _context.Turfs.Add(newturf);
            _context.SaveChanges();
        }

        public void UpdateTurf(Turf turf)
        {
            _context.Entry(turf).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTurf(int id)
        {
            var turf = _context.Turfs.Find(id);
            if (turf != null)
            {
                _context.Turfs.Remove(turf);
                _context.SaveChanges();
            }
        }
    }
}