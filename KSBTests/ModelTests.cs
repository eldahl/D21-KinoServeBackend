using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KinoServerBackend.Model;

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
            seat.ReservedBy = null;
            Assert.Equal(1, seat.ID);
            Assert.Equal(2, seat.Row);
            Assert.Equal(3, seat.Column);
            Assert.Null(seat.ReservedBy);
        }
    }
}
