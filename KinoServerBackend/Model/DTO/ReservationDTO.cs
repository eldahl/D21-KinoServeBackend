#pragma warning disable CS8618

namespace KinoServerBackend.Model.DTO
{
    public class ReservationDTO
    {
        public int ScreeningID { get; set; }
        public string CustomerEmail { get; set; }
        public SeatDTO[] Seats { get; set; } = new SeatDTO[0];
    }
}
