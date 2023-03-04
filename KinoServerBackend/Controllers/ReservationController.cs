using KinoServerBackend.Data;
using KinoServerBackend.Model;
using KinoServerBackend.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoServerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly DataContext _context;
        public ReservationController(DataContext context) {
            _context = context;
        }

        [HttpPost("MakeReservation")]
        public async Task<ActionResult> MakeReservation(ReservationDTO reservationDTO) {

            // Get the customer and screening from the database based on the IDs
            Reservation reservation = new Reservation();
            var ScreeningQuery = from s in _context.Screenings
                                 where s.ID == reservationDTO.ScreeningID
                                 select s;
            var CustomerQuery = from c in _context.Customers
                                where c.ID == reservationDTO.CustomerID
                                select c;

            // test if reservation.Screening contains an element
            foreach (Screening s in ScreeningQuery) {
                reservation.Screening = s;
                break;
            }
            foreach (Customer c in CustomerQuery) {
                reservation.Customer = c;
                break;
            }

            // Make sure Screening and Customer exist
            if (reservation.Screening is null || reservation.Customer is null) {
                return BadRequest("Invalid Screening or Customer ID!");
            }

            // Make sure all seats are available
            List<Seat> SeatsToReserve = new List<Seat>();
            foreach (SeatDTO seat in reservationDTO.Seats) {
                var SeatQuery = from s in _context.Seats
                                where s.Row == seat.Row && s.Column == seat.Column
                                select s;

                // See if seat is taken
                foreach (Seat _s in SeatQuery) {
                    return BadRequest("Seat already reserved!");
                }

                // Add to list of seats ot reserve
                SeatsToReserve.Add(new Seat {
                    Row = seat.Row,
                    Column = seat.Column,
                    ReservedBy = reservation
                });
            }
            
            // Add reservation to database
            _context.Reservations.Add(reservation);
            // Add seats to database
            _context.Seats.AddRange(SeatsToReserve);
            // save DB
            await _context.SaveChangesAsync();

            return Ok("Reservation made!");
        }

        [HttpGet("ResDTO")]
        public ActionResult ResDTO() {

            // Create new ReservationDTO example
            ReservationDTO reservationDTO = new ReservationDTO {
                CustomerID = 1,
                ScreeningID = 1,
                Seats = new SeatDTO[] {
                    new SeatDTO {
                        Row = 1,
                        Column = 1
                    },
                    new SeatDTO {
                        Row = 1,
                        Column = 2
                    },
                    new SeatDTO {
                        Row = 1,
                        Column = 3
                    }
                }
            };

            return Ok(reservationDTO);
        }

        [HttpGet("Pay")]
        public ActionResult Pay() {
            return new JavaScriptResult("<html><head></head><script>alert('Please pay for your reservation!');location.href = '/';</script><body></body></html>");
        }
    }
}
