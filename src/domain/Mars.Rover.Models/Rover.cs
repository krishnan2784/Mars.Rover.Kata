
using System;
using System.Linq;

namespace Mars.Rover.Models
{
    public class Rover
    {
        private const string Location = "0:0:N";
        private const char Separator = ':';
        private Direction _direction;
        private int x;
        private int y;
        public string Execute(string commands)
        {
            var location = Location.ToCharArray().Where(x => !x.Equals(Separator)).ToList();
            var directionString = location.LastOrDefault();
            var coOrdinates = location.Where(x => char.IsDigit(x)).ToList();
            if(coOrdinates.Count>2|| coOrdinates.Count<=0)
                throw new Exception("Invalid Coordinates");
            int.TryParse(coOrdinates.FirstOrDefault().ToString(),out x);
            int.TryParse(coOrdinates.LastOrDefault().ToString(), out y);
            _direction = new Direction(directionString,x, y );
            foreach (var command in commands.ToCharArray().ToList())
            {
                _direction = _direction.Rotate(command);
            }
            
            return $"{_direction.CurrentLocation.XCoordinate}:{_direction.CurrentLocation.YCoordinate}:{_direction.CurrentDirection}";

        }

        
    }
}
