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

        /// <summary>
        /// Gets the theater for a given screening
        /// </summary>
        /// <param name="sID">Screening ID</param>
        /// <returns></returns>
        [HttpGet("GetTheaterByScreeningID")]
        public ActionResult GetTheaterByScreeningID([FromQuery] int sID) {

            var query = from s in _context.Screenings
                        where s.ID == sID
                        select s.Theater;

            // Return first occurring theater
            foreach (Theater t in query) {
                return Ok(t);
            }

            return Ok();
        }

        /// <summary>
        /// Returns reserved seats for the given screening
        /// </summary>
        /// <param name="sID">Screening ID</param>
        /// <returns></returns>
        [HttpGet("GetSeatsByScreeningID")]
        public async Task<ActionResult<List<SeatDTO>>> GetSeatsByScreeningID([FromQuery] int sID) {
            var query = from s in _context.Seats
                        where s.ReservedBy.Screening.ID == sID
                        select s;

            // Create list of reserved seats
            List<SeatDTO> seatsReserved = new List<SeatDTO>();
            await query.ForEachAsync((seat) => {
                seatsReserved.Add(new SeatDTO() {
                    Row = seat.Row,
                    Column = seat.Column
                });
            });

            return Ok(seatsReserved);
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
