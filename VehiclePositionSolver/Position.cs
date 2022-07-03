

using GeoCoordinatePortable;

namespace VehiclePositionSolver
{
    public class Position
    {
        public int id;
        public float latitude;
        public float longitude;
        public GeoCoordinate geoCoordinate;

        public double latitudeRadians;
        public double longitudeRadians;

        public Position(int id, float latitude, float longitude) 
        {
            this.id = id;
            this.latitude = latitude;
            this.longitude = longitude;
            geoCoordinate = new GeoCoordinate(latitude, longitude);
            latitudeRadians = geoCoordinate.Latitude * Constants.DegreesToRadians;
            longitudeRadians = geoCoordinate.Longitude * Constants.DegreesToRadians;
        }

        public override string ToString()
        {
            return latitude.ToString("F8") + " " + longitude.ToString("F8");
        }
    }
}