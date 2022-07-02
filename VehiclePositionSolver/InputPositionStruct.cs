using GeoCoordinatePortable;

namespace VehiclePositionSolver
{
    public struct InputPositionStruct
    {
        public GeoCoordinate position;
        public double distance;
        public int bufferIndex;

        public InputPositionStruct(GeoCoordinate position, float distance, int bufferIndex)
        {
            this.position = position;
            this.distance = distance;
            this.bufferIndex = bufferIndex;
        }
    }
}