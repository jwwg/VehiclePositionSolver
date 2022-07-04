using GeoCoordinatePortable;
using VehiclePositionSolver;

namespace VehiclePositionSolver.Buffer
{
    internal class PositionBuffer : IPositionBuffer
    {
        private long bufferSize;
        private Position[] positions;
        private int _position;

        public PositionBuffer(long bufferSize)
        {
            this.bufferSize = bufferSize;
        }

        public long MaxIndex => bufferSize;

        public void AddPosition(Position position)
        {
            positions[_position] = position;
            _position++;
        }

        public Position CoordAt(long i) => positions[i];

        public Position Position(long i) => positions[i];

        public void PreAllocate()
        {
            _position = 0;
            positions = new Position[bufferSize];
        }
    }
}