using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Theater
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public int Capacity { get; set; }
        
        
    }
}
