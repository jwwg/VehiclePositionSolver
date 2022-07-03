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
                    double distance = Distance(inputPositions[j], positionBuffer.Position(i));
                    if (inputPositions[j].distance > distance)
                    {
                        inputPositions[j].distance = distance;
                        inputPositions[j].bufferIndex = i;
                    }
                }
            }
        }


        private double Distance(InputPosition from, Position other)
        {
            double num4 = other.longitudeRadians - from.longitudeRadians;
            double num5 = Math.Pow(Math.Sin((other.latitudeRadians - from.latitudeRadians) / 2.0), 2.0)  + 
                Math.Cos(from.latitudeRadians) * Math.Cos(other.latitudeRadians) * Math.Pow(Math.Sin(num4 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5)));
        }

    }
}