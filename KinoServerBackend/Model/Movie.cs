using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
