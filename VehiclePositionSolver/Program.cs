using CommandLine;
using GeoCoordinatePortable;
using VehiclePositionSolver.Pipeline;

Parser.Default.ParseArguments<PipelineOptions>(Environment.GetCommandLineArgs()).
        WithNotParsed(HandleBadInput).
        WithParsed(Process);

void Process(PipelineOptions pipelineOptions)
{
    Pipeline pipeline = new Pipeline();

    IPipelineReader pipeLineReader = StaticBuilder.Reader(pipelineOptions);
    IPipelineSolver solver = StaticBuilder.Solver(pipelineOptions);

    pipeline.
        AddReader(pipeLineReader).
        AddSolver(solver).
        Run();

}

void HandleBadInput(IEnumerable<Error> obj)
{
    Console.WriteLine("Invalid command line arguments. Use --help, or run with no parameters.");
}
