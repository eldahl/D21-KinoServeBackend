using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace KinoServerBackend.Model
{
    public class Seat
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public int Column { get; set; }
        [Required]
        public Reservation ReservedBy { get; set; }
        

    }
}
