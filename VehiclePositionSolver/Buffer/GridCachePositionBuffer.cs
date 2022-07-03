using GeoCoordinatePortable;

namespace VehiclePositionSolver.Buffer
{
    internal class GridCachePositionBuffer : IPositionBuffer
    {
        private long bufferSize;
        private Position[] positions;
        private int _position;
        public readonly GridCache.GridCache[] gridCache;

        public GridCachePositionBuffer(long bufferSize, GridCache.GridCache[] gridCache)
        {
            this.bufferSize = bufferSize;
            this.gridCache = gridCache;
        }

        public long MaxIndex => bufferSize;

        public void AddPosition(Position position)
        {
            positions[_position] = position;
            _position++;
            foreach (var grid in gridCache)
                grid.Add(position);
        }

        public GeoCoordinate CoordAt(long i) => positions[i].geoCoordinate;

        public Position Position(long i) => positions[i];

        public void PreAllocate()
        {
            _position = 0;
            positions = new Position[bufferSize];
        }
    }
}