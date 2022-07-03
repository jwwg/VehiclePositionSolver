using GeoCoordinatePortable;

namespace VehiclePositionSolver.GridCache
{


    /// <summary>
    /// Caches positions by defining a unique integer for each grid 
    /// (Storing the whole grid would be too memory-intensive)
    /// </summary>
    public class GridCache
    {
        private Dictionary<long, List<Position>> grid;
        public readonly long latMultiplier;
        public readonly long longMultiplier;
        private readonly int digits;
        private readonly long digitsMultiplier;

        public GridCache(int digits)
        {
            latMultiplier = Convert.ToInt64(Math.Pow(10, 3 + digits));
            longMultiplier = 1;
            digitsMultiplier = Convert.ToInt64(Math.Pow(10, digits));
            grid = new Dictionary<long, List<Position>>();

            this.digits = digits;
        }

        public long ToCache(GeoCoordinate coordinate)
        {
            return
                ToCachePart(coordinate.Latitude + 90, latMultiplier)
                +
                ToCachePart(coordinate.Longitude + 180, longMultiplier);
        }

        public long ToCachePart(double value, long cacheMultiplier)
        {
            return Convert.ToInt64(value * digitsMultiplier) * cacheMultiplier;
        }


        /// <summary>
        /// Build a combined list from a 3x3 grid with middle defined by position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal List<Position> PossiblePositions(GeoCoordinate position)
        {
            (long latitude, long longitude) = Decompose(ToCache(position));

            List<Position> result = new List<Position>();
            for (long i = latitude - 1; i <= latitude + 1; i++)
                for (long j = longitude - 1; j <= longitude + 1; j++)
                    result.AddRange(FromDecomposedValue(i, j));

            return result;
        }

        private List<Position> FromDecomposedValue(long latitude, long longitude)
        {
            long key = latitude * latMultiplier + longitude;
            if (grid.TryGetValue(key, out var value))
                return value;
            return new List<Position>();
        }

        public void Add(Position position)
        {
            long coord = ToCache(position.geoCoordinate);
            if (grid.TryGetValue(coord, out List<Position> positions))
            {
                positions.Add(position);
            }
            else grid[coord] = new List<Position>() { position };
        }

        public bool HasEntries(GeoCoordinate geoCoordinate)
        {
            long coord = ToCache(geoCoordinate);
            return grid.ContainsKey(coord);
        }

        public List<Position>? At(GeoCoordinate geoCoordinate)
        {
            long coord = ToCache(geoCoordinate);
            if (grid.TryGetValue(coord, out var values))
                return values;
            return null;
        }

        public (long latitude, long longitude) Decompose(long coord)
        {
            return (coord / latMultiplier, coord % latMultiplier);
        }
    }
}
