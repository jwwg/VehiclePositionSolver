using CommandLine;
using VehiclePositionSolver.Pipeline;

Parser.Default.ParseArguments<PipelineOptions>(Environment.GetCommandLineArgs()).
        WithNotParsed(HandleBadInput).
        WithParsed(Process);

void Process(PipelineOptions pipelineOptions)
{
    Pipeline pipeline = new Pipeline();

    IPipelineReader pipeLineReader = StaticBuilder.Reader(pipelineOptions);
    IPipelineSolver solver = StaticBuilder.Solver(pipelineOptions);
    IPipelineWriter writer = StaticBuilder.Writer(pipelineOptions);

    pipeline.
        AddReader(pipeLineReader).
        AddSolver(solver).
        AddWriter(writer).
        Run();

}

void HandleBadInput(IEnumerable<Error> obj)
{
    Console.WriteLine("Invalid command line arguments. Use --help, or run with no parameters.");
}
