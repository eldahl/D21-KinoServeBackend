using Newtonsoft.Json;

namespace KinoServerBackend.Model.DTO
{
    public class ScreeningsDTO
    {
        public Screening Screening { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
