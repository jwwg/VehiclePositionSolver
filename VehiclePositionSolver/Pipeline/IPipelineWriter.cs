namespace VehiclePositionSolver.Pipeline
{
    public interface IPipelineWriter
    {

        void WriteResults(InputPosition[] results, IPipelineReader reader);
    }
}