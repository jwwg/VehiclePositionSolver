using GeoCoordinatePortable;

namespace VehiclePositionLookup.Buffer
{
    public interface IPositionBuffer
    {
        long MaxIndex { get; }

        void PreAllocate();
        void AddPosition(PositionStruct position);
        GeoCoordinate At(long i);
    }
}