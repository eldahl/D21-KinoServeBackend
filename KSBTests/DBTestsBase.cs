using KinoServerBackend.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSBTests
{
    public class DBTestsBase : IDisposable
    {
        //public Mock<DataContext> MockDB;

        public DBTestsBase() {
            //MockDB.Setup(l => l.Reservations);
        }

        public void Dispose() {
            
        }
    }
}
