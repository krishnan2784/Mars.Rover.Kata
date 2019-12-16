using System.Collections.Generic;
using System.Linq;

namespace Mars.Rover.Models
{
    public class Direction
    {
        #region Public Fields

        public char CurrentDirection;
        private readonly int _maxGridHeight;
        private readonly int _maxGridWidth;
        public Direction(char direction, int xCoOrdinate, int yCoordinate, int maxGridHeight)
        {
            CurrentLocation = new CoOrdinate(xCoOrdinate, yCoordinate);
            CurrentDirection = Directions.FirstOrDefault(x => x.direction.Equals(direction)).direction;
            _maxGridHeight = maxGridHeight;
        }

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
            _maxGridHeight = 10;
            _maxGridWidth = 10;
        }
        public Direction(char direction, int xCoOrdinate, int yCoordinate, int maxGridHeight, int maxGridWidth)
        {
            CurrentLocation = new CoOrdinate(xCoOrdinate, yCoordinate);
            CurrentDirection = Directions.FirstOrDefault(x => x.direction.Equals(direction)).direction;
            _maxGridHeight = maxGridHeight;
            _maxGridWidth = maxGridWidth;
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
            MoveInTheHorizontalPlane();
            
            return this;
        }

        private void  MoveInTheVerticalPlane()
        {
            if (CurrentDirection.Equals('N'))
                CurrentLocation.YCoordinate = (CurrentLocation.YCoordinate + 1) % _maxGridHeight;
            if (CurrentDirection.Equals('S'))
            {
                if (CurrentLocation.YCoordinate == 1)
                    CurrentLocation.YCoordinate = 0;
                else
                    CurrentLocation.YCoordinate = (CurrentLocation.YCoordinate - 1) % _maxGridHeight;
            }
            
        }

        private void MoveInTheHorizontalPlane()
        {
            if (CurrentDirection.Equals('E'))
                CurrentLocation.XCoordinate = (CurrentLocation.XCoordinate + 1) % _maxGridWidth;
                
            if (CurrentDirection.Equals('W'))
                CurrentLocation.XCoordinate = (CurrentLocation.XCoordinate - 1) % _maxGridWidth;
        }

        #endregion Private Methods
    }
}