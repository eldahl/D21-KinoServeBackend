using System.ComponentModel.DataAnnotations;

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
    }
}
