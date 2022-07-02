// See https://aka.ms/new-console-template for more information
using VehiclePositionLookup;
using VehiclePositionLookup.Buffer;
using VehiclePositionLookup.Parser;

internal class PositionParser : IPositionParser
{
    private byte[] buffer = new byte[30];
    private int id;


    public IPositionBuffer PositionBuffer { get; set; }

    public bool ParseTo(MemoryStream stream)
    {
        id = 0;
        return ParseBuffer(stream.Read(buffer, 0, 30));
    }

    private bool ParseBuffer(int bytesRead)
    {
        if (bytesRead == 0) return false;
        
        PositionStruct position = new PositionStruct(id,
            latitude(), longitude());
        //Console.WriteLine(position);
        PositionBuffer.AddPosition(position);
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