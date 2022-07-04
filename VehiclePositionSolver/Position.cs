

using GeoCoordinatePortable;

namespace VehiclePositionSolver
{
    public class Position
    {
        public int id;
        public float latitude;
        public float longitude;
        public double latitudeRadians;
        public double longitudeRadians;

        public Position(int id, float latitude, float longitude) 
        {
            this.id = id;
            this.latitude = latitude;
            this.longitude = longitude;
            latitudeRadians = latitude * Constants.DegreesToRadians;
            longitudeRadians = longitude * Constants.DegreesToRadians;
        }

        public override string ToString()
        {
            return latitude.ToString("F8") + " " + longitude.ToString("F8");
        }

    }
}