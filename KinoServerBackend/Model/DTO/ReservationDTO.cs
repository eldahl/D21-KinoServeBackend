namespace KinoServerBackend.Model.DTO
{
    public class ReservationDTO
    {
        public int ScreeningID { get; set; }
        public int CustomerID { get; set; }
        public SeatDTO[] Seats { get; set; } = new SeatDTO[0];
    }
}
