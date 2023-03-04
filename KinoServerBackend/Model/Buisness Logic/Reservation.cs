

using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Screening Screening { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public float Price = 0;
        
        

    }
}
