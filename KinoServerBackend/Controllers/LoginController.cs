using KinoServerBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KinoServerBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext) {
            _dataContext = dataContext;
        }

        [HttpGet("Login")]
        public ActionResult<String> Get() {
            return Ok("Login attempt");
        }



    }
}
