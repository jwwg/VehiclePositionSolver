using VehiclePositionSolver.Buffer;

namespace VehiclePositionSolver.Pipeline
{
    public interface IPipelineReader
    {
        IPositionBuffer PositionBuffer { get; }

        void Read();
        string RegistrationNrAt(int bufferIndex);
    }
}