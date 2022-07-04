using GeoCoordinatePortable;
using VehiclePositionSolver.Buffer;

namespace VehiclePositionSolver.Pipeline
{
    public interface IPipelineSolver
    {
        InputPosition[] Results { get; }

        void Solve(InputPosition[] inputPositions, IPositionBuffer positionBuffer);
    }
}