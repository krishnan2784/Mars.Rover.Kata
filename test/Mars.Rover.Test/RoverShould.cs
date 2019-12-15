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
        [TestCase("R", ExpectedResult ="0:0:E")]
        [TestCase("RR", ExpectedResult ="0:0:S")]
        [TestCase("RRR", ExpectedResult ="0:0:W")]
        [TestCase("RRRR", ExpectedResult ="0:0:N")]
        public string RotateRight(string command)
        {
            var rover1 = new Models.Rover();
            var rover = rover1;
            return rover.Execute(command);
        }

        [Test]
        [TestCase("L", ExpectedResult ="0:0:W")]
        [TestCase("LL", ExpectedResult ="0:0:S")]
        [TestCase("LLL", ExpectedResult ="0:0:E")]
        [TestCase("LLLL", ExpectedResult ="0:0:N")]
        public string RotateLeft(string command)
        {
            var rover1 = new Models.Rover();
            var rover = rover1;
            return rover.Execute(command);
        }
    }
}