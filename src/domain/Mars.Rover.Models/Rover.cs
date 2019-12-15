using System;
using System.Linq;

namespace Mars.Rover.Models
{
    public class Rover
    {
        private readonly string _direction = "N";
        public string Execute(string commands)
        {
            var direction=_direction;
            foreach (var command in commands.ToCharArray().ToList())
            {
                if(command.Equals('R'))
                    direction = rotateRight(direction);
                if (command.Equals('L'))
                {
                    direction = rotateLeft(direction);
                }

                

            }


            return $"0:0:{direction}";

        }

        private string rotateLeft(string direction)
        {
            if (direction.Equals("N"))
            {
                return "W";
            }
            if (direction.Equals("E"))
            {
                return "N";
            }
            if (direction.Equals("S"))
            {
                return "E";
            }
            if (direction.Equals("W"))
            {
                return "S";
            }

            throw new Exception();
        }

        private string rotateRight(string direction)
        {
            if (direction.Equals("N"))
            {
                return "E";
            }
            if (direction.Equals("E"))
            {
                return "S";
            }
            if (direction.Equals("S"))
            {
                return "W";
            }
            if (direction.Equals("W"))
            {
                return "N";
            }

            throw new Exception();
        }
    }
}
