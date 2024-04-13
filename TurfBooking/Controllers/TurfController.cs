using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TurfBooking.Model;
using TurfBooking.Services;

namespace TurfBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurfController : ControllerBase
    {
        private readonly ITurfService _turfService;

        public TurfController(ITurfService turfService)
        {
            _turfService = turfService;
        }

        // GET: api/Turf
        [HttpGet]
        

        public ActionResult<IEnumerable<Turf>> GetTurfs()
        {
            var turfs = _turfService.GetTurfs();
            if (turfs == null)
            {
                return NotFound(); // Return a NotFoundResult if no users are found
            }
            return Ok(turfs);
        }

        // GET: api/Turf/5
        [HttpGet("{id}")]
        public ActionResult<Turf> GetTurf(int id)
        {
            var turf = _turfService.GetTurf(id);

            if (turf == null)
            {
                return NotFound();
            }

            return turf;
        }

        // POST: api/Turf
        [HttpPost]
        public ActionResult<Turf> PostTurf(Turf turf)
        {
            _turfService.AddTurf(turf);
            return CreatedAtAction("GetTurf", new { id = turf.Id }, turf);
        }

        // PUT: api/Turf/5
        [HttpPut("{id}")]
        public IActionResult PutTurf(int id, Turf turf)
        {
            if (id != turf.Id)
            {
                return BadRequest();
            }

            _turfService.UpdateTurf(turf);

            return NoContent();
        }

        // DELETE: api/Turf/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTurf(int id)
        {
            _turfService.DeleteTurf(id);
            return NoContent();
        }
    }
}