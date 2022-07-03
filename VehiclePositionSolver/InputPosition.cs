using GeoCoordinatePortable;

namespace VehiclePositionSolver
{
    public class InputPosition
    {
        public GeoCoordinate position;
        public double distance;
        public int bufferIndex;
        public double latitudeRadians;
        public double longitudeRadians;
        public Position positionStruct;

        public InputPosition(GeoCoordinate position, float distance, int bufferIndex)
        {
            this.position = position;
            this.distance = distance;
            this.bufferIndex = bufferIndex;
            latitudeRadians = position.Latitude * Constants.DegreesToRadians;
            longitudeRadians = position.Longitude * Constants.DegreesToRadians;
        }
    }
}