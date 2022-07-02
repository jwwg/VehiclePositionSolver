
using VehiclePositionSolver.Pipeline;
using VehiclePositionSolver.Readers;
using VehiclePositionSolver.Solver;

internal class StaticBuilder
{
    internal static IPipelineReader Reader(PipelineOptions pipelineOptions)
    {
        return pipelineOptions.Reader switch
        {
            _ => new FixedDataReader(bufferSize : pipelineOptions.FixedBufferSize,  fileName : pipelineOptions.DataFile)
        };
    }

    internal static IPipelineSolver Solver(PipelineOptions pipelineOptions)
    {
        return pipelineOptions.Solver switch
        {
            _ => new ClosestPositionSolver()
        };
    }
}