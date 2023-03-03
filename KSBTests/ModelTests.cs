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
            theater.Capacity = 52;

            Assert.Equal(1, theater.ID);
            Assert.Equal("Bollywood bombers", theater.Name);
            Assert.Equal(52, theater.Capacity);
        }

        [Fact]
        public void SeatCoverage() {
            Seat seat = new Seat();

            seat.ID = 1;
            seat.Row = 2;
            seat.Column = 3;
            seat.IsReserved = false;
            seat.ReservedBy = null;

            Assert.Equal(1, seat.ID);
            Assert.Equal(2, seat.Row);
            Assert.Equal(3, seat.Column);
            Assert.False(seat.IsReserved);
            Assert.Null(seat.ReservedBy);
        }
    }
}
