using GeoCoordinatePortable;

namespace VehiclePositionSolver
{
    public class InputPosition : Position
    {
        public double distance;
        public int bufferIndex;
        public Position positionStruct;

        public InputPosition(float latitude, float longitude) : base(-1, latitude, longitude)
        {
            distance = Constants.MaxDistance;
            bufferIndex = -1;
        }


    }
}