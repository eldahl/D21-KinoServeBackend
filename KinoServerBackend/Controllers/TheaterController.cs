using KinoServerBackend.Data;
using KinoServerBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoServerBackend.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly DataContext _context;
        public TheaterController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Theater>>> Get() {
            return Ok(await _context.Theaters.ToListAsync());
        }
    }
}
