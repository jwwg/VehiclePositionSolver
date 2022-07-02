using GeoCoordinatePortable;
using VehiclePositionLookup;
using VehiclePositionLookup.Buffer;

internal class PositionBuffer : IPositionBuffer
{
    private long bufferSize;
    private PositionStruct[] positions;
    private int _position;

    public PositionBuffer(long bufferSize)
    {
        this.bufferSize = bufferSize;
    }

    public long MaxIndex => bufferSize;

    public void AddPosition(PositionStruct position)
    {
        positions[_position] = position;
        _position++;
    }

    public GeoCoordinate At(long i) => positions[i].geoCoordinate;

    public void PreAllocate()
    {
        _position = 0;
        positions = new PositionStruct[bufferSize];
    }
}