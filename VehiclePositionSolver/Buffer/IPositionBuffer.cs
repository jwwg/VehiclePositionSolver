using GeoCoordinatePortable;
using VehiclePositionSolver;

namespace VehiclePositionSolver.Buffer
{
    public interface IPositionBuffer
    {
        long MaxIndex { get; }

        void PreAllocate();
        void AddPosition(PositionStruct position);
        GeoCoordinate At(long i);

    }
}