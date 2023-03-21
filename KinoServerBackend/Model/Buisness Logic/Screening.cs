using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace KinoServerBackend.Model
{
    public class Screening
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Theater Theater { get; set; } = default!;
        [Required]
        public Movie Movie { get; set; }
        [Required]
        public DateTime ScreeningTime { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
