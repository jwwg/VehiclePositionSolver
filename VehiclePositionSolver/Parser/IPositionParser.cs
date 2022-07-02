using VehiclePositionSolver.Buffer;

namespace VehiclePositionSolver.Parser
{
    public interface IPositionParser
    {
        IPositionBuffer PositionBuffer { get; set; }

        bool ParseTo(MemoryStream stream);
    }
}