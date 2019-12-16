using System.Collections.Generic;
using System.Linq;

namespace Mars.Rover.Models
{
    public class Direction
    {
        #region Public Fields

        public char CurrentDirection;

        #endregion Public Fields



        #region Public Constructors

        public Direction(char direction)
        {
            CurrentDirection = Directions.FirstOrDefault(x => x.direction.Equals(direction)).direction;
        }

        public Direction(char direction, int xCoOrdinate, int yCoordinate)
        {
            CurrentLocation = new CoOrdinate(xCoOrdinate, yCoordinate);
            CurrentDirection = Directions.FirstOrDefault(x => x.direction.Equals(direction)).direction;
        }

        #endregion Public Constructors



        #region Public Properties

        public CoOrdinate CurrentLocation { get; private set; }

        #endregion Public Properties



        #region Private Properties

        private IEnumerable<(char direction, char leftDirection, char rightDirection)> Directions =>
            new List<(char direction, char leftDirection, char rightDirection)>
                {
                    ('N', 'W', 'E'),
                    ('E', 'N', 'S'),
                    ('S', 'E', 'W'),
                    ('W', 'S', 'N')
                };

        #endregion Private Properties



        #region Public Methods

        public Direction MoveRover(char command)
        {
            var (_, leftDirection, rightDirection) = Directions.FirstOrDefault(x => x.direction.Equals(CurrentDirection));
            if (command.Equals('R'))
                return new Direction(rightDirection, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);
            if (command.Equals('L'))
                return new Direction(leftDirection, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);
            if (command.Equals('M'))
                return Move();
            return new Direction(CurrentDirection);
        }

        #endregion Public Methods



        #region Private Methods

        private Direction Move()
        {

            MoveInTheVerticalPlane();
            
            if (CurrentDirection.Equals('E'))
                CurrentLocation.XCoordinate++;
            if (CurrentDirection.Equals('W'))
                CurrentLocation.XCoordinate--;
            return this;
        }

        private void  MoveInTheVerticalPlane()
        {
            if (CurrentDirection.Equals('N'))
                CurrentLocation.YCoordinate++;
            if (CurrentDirection.Equals('S'))
                CurrentLocation.YCoordinate--;
        }

        private Direction MoveForward()
        {
            
            return this;
        }

        #endregion Private Methods
    }
}