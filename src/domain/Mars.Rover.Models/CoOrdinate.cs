namespace Mars.Rover.Models
{
    public class CoOrdinate
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public CoOrdinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}