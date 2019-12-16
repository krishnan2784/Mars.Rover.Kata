
using System;
using System.Linq;

namespace Mars.Rover.Models
{
    public class Rover
    {
        private const char Location = 'N';
        private Direction _direction = new Direction(Location, 0,0);
        
        public string Execute(string commands)
        {
            foreach (var command in commands.ToCharArray().ToList())
            {
                _direction = _direction.MoveRover(command);
            }
            
            return $"{_direction.CurrentLocation.XCoordinate}:{_direction.CurrentLocation.YCoordinate}:{_direction.CurrentDirection}";

        }

        
    }
}
