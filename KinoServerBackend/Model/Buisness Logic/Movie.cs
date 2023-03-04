using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string ImageLink { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
    }
}
