using VehiclePositionSolver.Buffer;
using VehiclePositionSolver.Readers;
using VehiclePositionSolver.Solver;
using VehiclePositionSolver.Writers;

namespace VehiclePositionSolver.Pipeline
{
    internal class StaticBuilder
    {
        internal static IPipelineReader Reader(PipelineOptions pipelineOptions)
        {
            IPositionBuffer buffer;
            if (pipelineOptions.Solver == nameof(GridSolver))
                buffer = new GridCachePositionBuffer(pipelineOptions.FixedBufferSize, GridCaches(pipelineOptions));
            else
                buffer = new PositionBuffer(pipelineOptions.FixedBufferSize);

            return pipelineOptions.Reader switch
            {
                _ => new FixedDataReader(buffer, fileName: pipelineOptions.DataFile)
            };
        }

        internal static IPipelineWriter Writer(PipelineOptions pipelineOptions)
        {
            return pipelineOptions.Output switch
            {
                _ => new TextResults(),
            };
        }

        private static GridCache.GridCache[] GridCaches(PipelineOptions pipelineOptions)
        {
            return new GridCache.GridCache[] { new GridCache.GridCache(2) };
        }

        internal static IPipelineSolver Solver(PipelineOptions pipelineOptions)
        {
            return pipelineOptions.Solver switch
            {
                nameof(AlternateSolver) => new AlternateSolver(),
                nameof(GridSolver) => new GridSolver(),
                _ => new BruteForceSolver()
            };
        }
    }
}