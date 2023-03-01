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
        public void Test2() {
            Console.WriteLine("Test02");
            Assert.Equal(2, 2);
        }
    }
}