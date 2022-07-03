using CommandLine;

namespace VehiclePositionSolver.Pipeline
{
    public class PipelineOptions
    {
        [Option(Default = "FixedReader")]
        public string Reader { get; set; }

        [Option(Default = "BasicSolver", HelpText = "Use BasicSolver or GridSolver")]
        public string Solver { get; set; }

        [Option(Default = 2000000, HelpText = "Number of records in data file")]
        public long FixedBufferSize { get; set; }

        [Option(Default = "VehiclePositions.dat", HelpText = "File with position data")]
        public string DataFile { get; set; }
    }
}