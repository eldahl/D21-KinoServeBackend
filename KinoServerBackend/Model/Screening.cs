using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinoServerBackend.Model
{
    public class Screening
    {
        [Key]
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public DateTime ScreeningTime { get; set; }
        

    }
}
