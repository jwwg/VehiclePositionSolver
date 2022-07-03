// See https://aka.ms/new-console-template for more information
using VehiclePositionSolver;
using VehiclePositionSolver.Buffer;
using VehiclePositionSolver.Parser;

internal class PositionParser : IPositionParser
{
    private byte[] buffer = new byte[30];
    private int id;


    public IPositionBuffer PositionBuffer { get; set; }

    public PositionParser()
    {
        id = 0;
    }

    public bool ParseTo(MemoryStream stream)
    {
        return ParseBuffer(stream.Read(buffer, 0, 30));
    }

    private bool ParseBuffer(int bytesRead)
    {
        if (bytesRead == 0) return false;
        
        Position position = new Position(id,
            latitude(), longitude());
        PositionBuffer.AddPosition(position);
        id++;
        return true;
    }

    private float latitude()
    {
        return BitConverter.ToSingle(buffer, 14);
    }

    private float longitude()
    {
        return BitConverter.ToSingle(buffer, 18);
    }

}