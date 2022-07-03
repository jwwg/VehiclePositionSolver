using GeoCoordinatePortable;
using VehiclePositionSolver;

namespace VehiclePositionSolver.Buffer
{
    public interface IPositionBuffer
    {
        long MaxIndex { get; }

        void PreAllocate();
        void AddPosition(Position position);
        GeoCoordinate CoordAt(long i);

        Position Position(long i);

    }
}