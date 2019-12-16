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
            var rover = new Models.Rover();
            return rover.Execute(command);
        }

        [Test]
        [TestCase("L", ExpectedResult ="0:0:W")]
        [TestCase("LL", ExpectedResult ="0:0:S")]
        [TestCase("LLL", ExpectedResult ="0:0:E")]
        [TestCase("LLLL", ExpectedResult ="0:0:N")]
        public string RotateLeft(string command)
        {
            var rover = new Models.Rover();
            return rover.Execute(command);
        }

        [Test]
        [TestCase("F", ExpectedResult ="0:1:N")]
        [TestCase("FF", ExpectedResult ="0:2:N")]
        [TestCase("FFF", ExpectedResult ="0:3:N")]
        [TestCase("FFFF", ExpectedResult ="0:4:N")]
        public string MoveForward(string command)
        {
            var rover = new Models.Rover();
            return rover.Execute(command);
        }
    }
}