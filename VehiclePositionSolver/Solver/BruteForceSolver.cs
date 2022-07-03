using GeoCoordinatePortable;
using VehiclePositionSolver.Buffer;
using VehiclePositionSolver.Pipeline;

namespace VehiclePositionSolver.Solver
{
    internal class BruteForceSolver : IPipelineSolver
    {

        private InputPosition[] inputPositions;

        readonly private float MaxDistance = 21000000; // 21,000 km = 21,000,000 m

        public InputPosition[] Results => inputPositions;

        public void Solve(GeoCoordinate[] geoCoordinates, IPositionBuffer positionBuffer)
        {
            inputPositions =
                geoCoordinates.Select(x => new InputPosition(
                    x, MaxDistance, -1
                    )).ToArray();

            for (int i = 0; i < positionBuffer.MaxIndex; i++)
            {
                for (int j = 0; j < inputPositions.Length; j++)
                {
                    double distance = inputPositions[j].position.GetDistanceTo(positionBuffer.CoordAt(i));
                    if (inputPositions[j].distance > distance)
                    {
                        inputPositions[j].distance = distance;
                        inputPositions[j].bufferIndex = i;
                    }
                }
            }
        }
    }
}