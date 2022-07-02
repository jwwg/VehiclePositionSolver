

using GeoCoordinatePortable;

namespace VehiclePositionSolver
{
    public struct PositionStruct
    {
        public int id;
        public float latitude;
        public float longitude;
        public GeoCoordinate geoCoordinate;


        public PositionStruct(int id, float latitude, float longitude) : this()
        {
            this.id = id;
            this.latitude = latitude;
            this.longitude = longitude;
            geoCoordinate = new GeoCoordinate(latitude, longitude);
        }

        public override string ToString()
        {
            return latitude.ToString("F8") + " " + longitude.ToString("F8");
        }
    }
}