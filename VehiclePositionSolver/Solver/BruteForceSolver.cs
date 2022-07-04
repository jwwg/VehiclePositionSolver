using GeoCoordinatePortable;
using VehiclePositionSolver.Buffer;
using VehiclePositionSolver.Pipeline;

namespace VehiclePositionSolver.Solver
{
    internal class BruteForceSolver : IPipelineSolver
    {

        private InputPosition[] inputPositions;

        public InputPosition[] Results => inputPositions;

        public void Solve(InputPosition[] inputPositions, IPositionBuffer positionBuffer)
        {
            this.inputPositions = inputPositions;
            for (int i = 0; i < positionBuffer.MaxIndex; i++)
            {
                for (int j = 0; j < inputPositions.Length; j++)
                {
                    double distance = StaticMath.Distance(inputPositions[j],positionBuffer.CoordAt(i));
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