using KinoServerBackend.Data;
using KinoServerBackend.Model;
using KinoServerBackend.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.HttpLogging;

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
                    join m in _context.Movies on s.Movie.Name equals m.Name
                    select new { s, m };

            List<ScreeningsDTO> screenings = new List<ScreeningsDTO>();
            foreach (var record in query) {
                screenings.Add(new ScreeningsDTO {
                    Screening = record.s,
                    Duration = record.m.Duration
                });
            }
            return Ok(screenings);
        }

        [HttpGet("GetScreeningsByID")]
        public ActionResult<List<ScreeningsDTO>> GetScreeningsByID([FromQuery] int id) {

            // No movie name provided equals return all screenings
            var query = from s in _context.Screenings
                        join m in _context.Movies on s.Movie.Name equals m.Name
                        where m.ID == id
                        select new { s, m };

            List<ScreeningsDTO> screenings = new List<ScreeningsDTO>();
            foreach (var record in query) {
                screenings.Add(new ScreeningsDTO {
                    Screening = record.s,
                    Duration = record.m.Duration
                });
            }
            return Ok(screenings);
        }
    }
}
