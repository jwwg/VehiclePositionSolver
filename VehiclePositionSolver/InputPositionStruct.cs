// See https://aka.ms/new-console-template for more information
using GeoCoordinatePortable;

namespace VehiclePositionLookup
{
    internal struct InputPositionStruct
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