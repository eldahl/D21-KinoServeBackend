using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Seat
    {
        [Key]
        public int ID { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsReserved { get; set; }
        

    }
}
