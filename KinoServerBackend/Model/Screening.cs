using System;
using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ScreeningTime { get; set; }
        

    }
}
