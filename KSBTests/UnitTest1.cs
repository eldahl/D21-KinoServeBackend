using KinoServerBackend.Model;

namespace KSBTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1() {
            Console.WriteLine("Test01");
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Base64Encode() {
            Assert.Equal("VGVzdCAxMjM=", Base64.Encode("Test 123"));
        }

        [Fact]
        public void Base64Decode() {
            Assert.Equal("Test 123", Base64.Decode("VGVzdCAxMjM="));
        }
    }
}