// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using VehiclePositionLookup;
using VehiclePositionLookup.Buffer;

internal class ClosestPositionSolver
{
    private object inputValues;
    private IPositionBuffer positionBuffer;
    private InputPositionStruct[] inputPositions;

    readonly private float MaxDistance = 21000000; // 21,000 km = 21,000,000 m

    public InputPositionStruct[] Results => inputPositions;

    public ClosestPositionSolver(GeoCoordinatePortable.GeoCoordinate[] inputValues, IPositionBuffer positionBuffer)
    {
        this.inputValues = inputValues;
        inputPositions =
            inputValues.Select(x => new InputPositionStruct(
                x, MaxDistance, -1 
                )).ToArray();

        this.positionBuffer = positionBuffer;
    }

    public long Solve()
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        for (int i = 0; i < positionBuffer.MaxIndex; i ++)
        {
            for (int j = 0; j < inputPositions.Length; j ++)
            {
                double distance = inputPositions[j].position.GetDistanceTo(positionBuffer.At(i));
                if (inputPositions[j].distance > distance)
                {
                    inputPositions[j].distance = distance;
                    inputPositions[j].bufferIndex = i;
                }
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Process time mS: " + stopwatch.ElapsedMilliseconds);
        return stopwatch.ElapsedMilliseconds;
    }
}