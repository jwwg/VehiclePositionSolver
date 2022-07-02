using VehiclePositionLookup.Buffer;

namespace VehiclePositionLookup.Parser
{
    public interface IPositionParser
    {
        IPositionBuffer PositionBuffer { get; set; }

        bool ParseTo(MemoryStream stream);
    }
}