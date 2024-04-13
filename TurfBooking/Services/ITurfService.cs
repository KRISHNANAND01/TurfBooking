using System.Collections.Generic;
using TurfBooking.Model;

namespace TurfBooking.Services
{
    public interface ITurfService
    {
        IEnumerable<Turf> GetTurfs();
        Turf GetTurf(int id);
        void AddTurf(Turf turf);
        void UpdateTurf(Turf turf);
        void DeleteTurf(int id);
    }
}