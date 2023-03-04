using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Theater
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Rows { get; set; }
        [Required]
        public int Columns { get; set; }


    }
}
