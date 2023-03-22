using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KinoServerBackend.Model;
using KinoServerBackend.Model.DTO;

namespace KSBTests
{
    public class ModelTests {
        [Fact]
        public void TheaterCoverage() {
            Theater theater = new Theater();
            
            theater.ID = 1;
            theater.Name = "Bollywood bombers";
            
            Assert.Equal(1, theater.ID);
            Assert.Equal("Bollywood bombers", theater.Name);
        }

        [Fact]
        public void SeatCoverage() {
            Seat seat = new Seat();
            
            seat.ID = 1;
            seat.Row = 2;
            seat.Column = 3;
            seat.ReservedBy = null!;
            Assert.Equal(1, seat.ID);
            Assert.Equal(2, seat.Row);
            Assert.Equal(3, seat.Column);
            Assert.Null(seat.ReservedBy);
        }

        [Fact]
        public void SeatDTOCoverage() {
            SeatDTO seatDTO = new SeatDTO();

            seatDTO.Column = 1;
            seatDTO.Row = 1;
            Assert.Equal(1, seatDTO.Column);
            Assert.Equal(1, seatDTO.Row);

        }

        [Fact]
        public void ScreeningCoverage() {
            Screening s = new Screening();

            s.ID = 1;
            s.Theater = null!;
            s.Movie = null!;
            s.ScreeningTime = DateTime.Today;
            s.Price = 100;

            Assert.Equal(1, s.ID);
            Assert.Null(s.Theater);
            Assert.Null(s.Movie);
            Assert.Equal(DateTime.Today, s.ScreeningTime);
            Assert.Equal(100, s.Price);
        }
        
        [Fact]
        public void ScreeningsDTOCoverage() {
            ScreeningsDTO s = new ScreeningsDTO();

            s.Screening = null!;
            s.Duration = TimeSpan.Zero;

            Assert.Equal(TimeSpan.Zero, s.Duration);
            Assert.Null(s.Screening);
        }

        [Fact]
        public void ReservationCoverage() {
            Reservation r = new Reservation();

            r.ID = 1;
            r.Screening = null!;
            r.Customer = null!;
            r.Price = 100;

            Assert.Equal(1, r.ID);
            Assert.Null(r.Screening);
            Assert.Null(r.Customer);
            Assert.Equal(100, r.Price);
        }

        [Fact]
        public void ReservationDTOCoverage() {
            ReservationDTO r = new ReservationDTO();

            r.ScreeningID = 1;
            r.CustomerEmail = "test@test.com";
            r.Seats = null!;

            Assert.Equal(1, r.ScreeningID);
            Assert.Equal("test@test.com", r.CustomerEmail);
            Assert.Null(r.Seats);
        }

        [Fact]
        public void MovieCoverage() {
            Movie m = new Movie();

            m.ID = 1;
            m.Name = "George";
            m.ImageLink = "http://img.com/1234";
            m.Description = "Panda";
            m.ReleaseDate = DateTime.Today;
            m.Duration = TimeSpan.Zero;

            Assert.Equal(1, m.ID);
            Assert.Equal("George", m.Name);
            Assert.Equal("http://img.com/1234", m.ImageLink);
            Assert.Equal("Panda", m.Description);
            Assert.Equal(DateTime.Today, m.ReleaseDate);
            Assert.Equal(TimeSpan.Zero, m.Duration);
        }

        [Fact]
        public void CustomerCoverage() {
            Customer c = new Customer();

            c.Email = "test@test.com";
            c.FirstName = "George";
            c.LastName = "Hotz";
            c.Password = "Gorillas";
            c.Phone = "12345678";
            c.Address = "Street 123";
            c.City = "Townsvile";
            c.ZipCode = "12345";
            c.Country = "United States";

            Assert.Equal("test@test.com", c.Email);
            Assert.Equal("George", c.FirstName);
            Assert.Equal("Hotz", c.LastName);
            Assert.Equal("Gorillas", c.Password);
            Assert.Equal("12345678", c.Phone);
            Assert.Equal("Street 123", c.Address);
            Assert.Equal("Townsvile", c.City);
            Assert.Equal("12345", c.ZipCode);
            Assert.Equal("United States", c.Country);

            Customer cust = new Customer();
            cust.Email = "test2@test2.com";
            cust.FirstName = "Hannibal";
            cust.LastName = "Humbucker";
            cust.Password = "guitarsolo123";
            cust.Phone = "87654321";
            cust.Address = "123 Street";
            cust.City = "Townsvile";
            cust.ZipCode = "12345";
            cust.Country = "United States";

            cust.Update(c);

            Assert.Equal("test@test.com", c.Email);
            Assert.Equal("George", c.FirstName);
            Assert.Equal("Hotz", c.LastName);
            Assert.Equal("Gorillas", c.Password);
            Assert.Equal("12345678", c.Phone);
            Assert.Equal("Street 123", c.Address);
            Assert.Equal("Townsvile", c.City);
            Assert.Equal("12345", c.ZipCode);
            Assert.Equal("United States", c.Country);

        }
    }
}
