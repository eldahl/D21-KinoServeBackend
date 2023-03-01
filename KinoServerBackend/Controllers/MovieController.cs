using KinoServerBackend.Data;
using KinoServerBackend.Model;
using KinoServerBackend.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace KinoServerBackend.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;
        public MovieController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get() {
            return Ok(await _context.Movies.ToListAsync());
        }

        [HttpGet("GetScreenings")]
        public ActionResult<List<ScreeningsDTO>> GetScreenings() {

            var query = from s in _context.Screenings
                        join m in _context.Movies on s.MovieName equals m.Name
                        select new { s, m.Duration };

            List<ScreeningsDTO> screenings = new List<ScreeningsDTO>();
            foreach(var record in query) {
                screenings.Add(new ScreeningsDTO {
                    _screening = record.s,
                    _duration = record.Duration
                });
            }

            return Ok(screenings);
        }
    }
}
