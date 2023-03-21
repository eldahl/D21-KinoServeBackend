using Newtonsoft.Json;

#pragma warning disable CS8618

namespace KinoServerBackend.Model.DTO
{
    public class ScreeningsDTO
    {
        public Screening Screening { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
