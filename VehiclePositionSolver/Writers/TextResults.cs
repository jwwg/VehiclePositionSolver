using VehiclePositionSolver.Pipeline;

namespace VehiclePositionSolver.Writers
{
    internal class TextResults : IPipelineWriter
    {

        public void WriteResults(InputPosition[] results, IPipelineReader reader)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result.distance.ToString("F2") + " m, vehicle  "
                    + reader.RegistrationNrAt(result.bufferIndex) + " closest to "
                    + result + " is "
                    + reader.PositionBuffer.CoordAt(result.bufferIndex));
            }

        }
    }
}