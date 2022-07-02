using GeoCoordinatePortable;
using VehiclePositionLookup.Buffer;
using VehiclePositionLookup.DataLoad;
using VehiclePositionLookup.Parser;

long bufferSize = 2000000;

Console.WriteLine("Reading");
IPositionBuffer positionBuffer = new PositionBuffer(bufferSize);
IPositionParser positionParser = new PositionParser();
var dataLoader = new DataLoader(positionBuffer, positionParser);
long totalMs = dataLoader.Load();
Console.WriteLine("Read time " + totalMs);

GeoCoordinate[] geoCoordinates = CoordinateInitialiser.Init();
var resolver = new ClosestPositionSolver(geoCoordinates, positionBuffer);
totalMs += resolver.Solve();
foreach (var result in resolver.Results)
{
    Console.WriteLine(result.distance + " distance, index  " + result.bufferIndex);
}
Console.WriteLine("Total time " + totalMs);

