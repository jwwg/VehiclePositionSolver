namespace VehiclePositionSolver.Buffer
{
    public interface IPositionBuffer
    {
        long MaxIndex { get; }

        void PreAllocate();
        void AddPosition(Position position);
        Position CoordAt(long i);

        Position Position(long i);

    }
}