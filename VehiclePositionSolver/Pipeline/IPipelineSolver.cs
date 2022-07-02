using GeoCoordinatePortable;
using VehiclePositionSolver.Buffer;

namespace VehiclePositionSolver.Pipeline
{
    public interface IPipelineSolver
    {
        InputPositionStruct[] Results { get; }

        void Solve(GeoCoordinate[] geoCoordinates, IPositionBuffer positionBuffer);
    }
}