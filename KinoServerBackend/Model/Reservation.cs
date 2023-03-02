

using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        public Screening Screening { get; set; }
        
        

    }
}
