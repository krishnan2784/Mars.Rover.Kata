using NUnit.Framework;

namespace Mars.Rover.Test
{
    public class RoverShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RotateRight()
        {
            var rover1 = new Models.Rover();
            var rover = rover1;
            Assert.IsTrue(rover.Execute("")== "0:0:E");
        }
    }
}