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
        [TestCase("M", ExpectedResult ="0:1:N")]
        [TestCase("MM", ExpectedResult ="0:2:N")]
        [TestCase("MMM", ExpectedResult ="0:3:N")]
        [TestCase("MMMM", ExpectedResult ="0:4:N")]
        public string MoveUp(string command)
        {
            var rover = new Models.Rover();
            return rover.Execute(command);
        }

        [Test]
        [TestCase("MRRMLL", ExpectedResult ="0:0:N")]
        [TestCase("MMLLMMRR", ExpectedResult ="0:0:N")]
        [TestCase("MMMRRMMM", ExpectedResult ="0:0:S")]
        [TestCase("MMMMLLMMMM", ExpectedResult ="0:0:S")]
        public string MoveUpAndDown(string command)
        {
            var rover = new Models.Rover();
            return rover.Execute(command);
        }

        [Test]
        [TestCase("RMLLMR", ExpectedResult ="0:0:N")]
        [TestCase("RMMLLMMR", ExpectedResult ="0:0:N")]
        [TestCase("RMMMLLMMMR", ExpectedResult ="0:0:N")]
        [TestCase("RMMMMLLMMMMR", ExpectedResult ="0:0:N")]
        public string MoveSideToSide(string command)
        {
            var rover = new Models.Rover();
            return rover.Execute(command);
        }

        [Test]
        [TestCase("MRMRMRM", ExpectedResult ="0:0:W")]
        [TestCase("MMRMMRMMRMM", ExpectedResult ="0:0:W")]
        [TestCase("MMMRMMMRMMMRMMM", ExpectedResult ="0:0:W")]
        [TestCase("MMMMRMMMMRMMMMRMMMM", ExpectedResult ="0:0:W")]
        public string MoveInASquare(string command)
        {
            var rover = new Models.Rover();
            return rover.Execute(command);
        }
        [Test]
        [TestCase("MMMMMMMMMM", ExpectedResult ="0:0:N")]
        public string MoveUpWithWrapAround(string command)
        {
            var rover = new Models.Rover();
            return rover.Execute(command);
        }
    }
}