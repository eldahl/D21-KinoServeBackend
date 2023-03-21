using KinoServerBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KinoServerBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace KinoServerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CustomerController(DataContext dataContext) {
            _dataContext = dataContext;
        }

        [HttpPost("PostCustomer")]
        public async Task<ActionResult<String>> PostCustomer([FromBody] Customer customer) {
            
            Customer? cust = await _dataContext.Customers.FindAsync(customer.Email);

            if (cust is null) {
                // Insert
                await _dataContext.Customers.AddAsync(customer);
                await _dataContext.SaveChangesAsync();
            } else {
                // Update
                cust.Update(customer);
                _dataContext.Update(cust);
                await _dataContext.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("GetCustomer")]
        public async Task<ActionResult<Customer>> GetCustomer([FromQuery] String email) {

            // Get customer from the database context
            Customer? customer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Email == email);

            if (customer is null) {
                return BadRequest("Customer not found!");
            }

            return Ok(customer);
        }
    }
}
