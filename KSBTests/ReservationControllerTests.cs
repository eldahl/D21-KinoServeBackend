using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinoServerBackend.Controllers;
using Moq;
using KinoServerBackend.Data;

namespace KSBTests
{
    public class ReservationControllerTests : IClassFixture<DBTestsBase>
    {
        //Mock<DataContext> mockDB;
        //DataContext context;

        public ReservationControllerTests(DBTestsBase data) {
            //mockDB = data.MockDB;
            //context = mockDB.Object;
        }

        [Fact]
        public void GetSeatsByScreeningIDTest01() {

            Assert.Equal(1, 1);
        }

    }
}
