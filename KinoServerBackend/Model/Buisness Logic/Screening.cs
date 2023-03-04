using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Screening
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Theater Theater { get; set; }
        [Required]
        public Movie Movie { get; set; }
        [Required]
        public DateTime ScreeningTime { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
