using GeoCoordinatePortable;
using VehiclePositionSolver.Buffer;
using VehiclePositionSolver.Pipeline;

namespace VehiclePositionSolver.Solver
{
    internal class AlternateSolver : IPipelineSolver
    {

        private InputPosition[] inputPositions;

        readonly private float MaxDistance = 21000000; // 21,000 km = 21,000,000 m

        public InputPosition[] Results => inputPositions;

        public void Solve(InputPosition[] inputPositions, IPositionBuffer positionBuffer)
        {

            for (int i = 0; i < positionBuffer.MaxIndex; i++)
            {
                for (int j = 0; j < inputPositions.Length; j++)
                {
                    double distance = StaticMath.SquareDistance(inputPositions[j], positionBuffer.Position(i));
                    if (inputPositions[j].distance > distance)
                    {
                        inputPositions[j].distance = distance;
                        inputPositions[j].bufferIndex = i;
                    }
                }
            }

            for (int i = 0; i < inputPositions.Length; i++)
                inputPositions[i].distance = StaticMath.Distance(inputPositions[i], positionBuffer.Position(inputPositions[i].bufferIndex));
        }

    }
}