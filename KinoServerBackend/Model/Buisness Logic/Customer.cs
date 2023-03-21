using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace KinoServerBackend.Model
{
    public class Customer
    {
        [Key]
        public string Email { get; set; } = "";
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string Phone { get; set; } = "";
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }

        public void Update(Customer c) {
            this.FirstName = c.FirstName;
            this.LastName = c.LastName;
            this.Password = c.Password;
            this.Phone = c.Phone;
            this.Address = c.Address;
            this.City = c.City;
            this.ZipCode = c.ZipCode;
            this.Country = c.Country;
        }
    }
}
