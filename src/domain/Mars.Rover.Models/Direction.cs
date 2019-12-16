using System;
using System.Collections.Generic;
using System.Linq;

namespace Mars.Rover.Models
{
    public class Direction
    {
        public CoOrdinate CurrentLocation { get; private set; }
        public Direction(char direction)
        {
            CurrentDirection = Directions.FirstOrDefault(x => x.direction.Equals(direction)).direction;
            
        }



        private IEnumerable<(char direction, char leftDirection, char rightDirection)> Directions =>
            new List<(char direction, char leftDirection, char rightDirection)>
                {
                    ('N', 'W', 'E'),
                    ('E', 'N', 'S'),
                    ('S', 'E', 'W'),
                    ('W', 'S', 'N')
                };

        public char CurrentDirection;

        public Direction(char direction, int xCoOrdinate, int yCoordinate)
        {
            CurrentLocation = new CoOrdinate(xCoOrdinate, yCoordinate);
            CurrentDirection = Directions.FirstOrDefault(x => x.direction.Equals(direction)).direction;
        }

        public Direction Rotate(char command)
        {
            var (direction, leftDirection, rightDirection) = Directions.FirstOrDefault(x => x.direction.Equals(CurrentDirection));
            if (command.Equals('R'))
                return new Direction(rightDirection, this.CurrentLocation.XCoordinate, this.CurrentLocation.YCoordinate);

            if (command.Equals('L'))
                return new Direction(leftDirection, this.CurrentLocation.XCoordinate, this.CurrentLocation.YCoordinate);
            if (command.Equals('F'))
                return MoveFoward();
            return new Direction(CurrentDirection);
        }

        private Direction MoveFoward()
        {
            if(CurrentDirection.Equals('N'))
                CurrentLocation.YCoordinate++;
            if(CurrentDirection.Equals('S'))
                CurrentLocation.YCoordinate--;
            if(CurrentDirection.Equals('E'))
                CurrentLocation.XCoordinate++;
            if(CurrentDirection.Equals('W'))
                CurrentLocation.XCoordinate--;
            return this;
        }
    }
}