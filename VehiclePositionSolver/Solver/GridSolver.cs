using GeoCoordinatePortable;
using VehiclePositionSolver.Buffer;
using VehiclePositionSolver.Pipeline;

namespace VehiclePositionSolver.Solver
{
    internal class GridSolver : IPipelineSolver
    {

        private InputPosition[] inputPositions;

        readonly private float MaxDistance = 21000000; // 21,000 km = 21,000,000 m

        public InputPosition[] Results => inputPositions;

        public void Solve(InputPosition[] inputPositions, IPositionBuffer positionBuffer)
        {
            GridCachePositionBuffer gridCachePositionBuffer = (GridCachePositionBuffer) positionBuffer;
            var gridCache = gridCachePositionBuffer.gridCache[0];

            for (int j = 0; j < inputPositions.Length; j++)
            {
                var list = gridCache.
                    PossiblePositions(inputPositions[j]);
                    
                if (list != null && list.Count > 0)
                {
                    FindBestIn(list, inputPositions[j]);
                }
                else //bad cache miss - should actually go to a less refined gridCache, but for the supplied data wasn't required
                {
                    FallbackSolve(inputPositions[j], positionBuffer);
                }
            }
        }

        private void FallbackSolve(InputPosition inputPosition, IPositionBuffer positionBuffer)
        {
            for (int i = 0; i < positionBuffer.MaxIndex; i++)
            {
                double distance = StaticMath.Distance(inputPosition, positionBuffer.CoordAt(i));
                if (inputPosition.distance > distance)
                {
                    inputPosition.distance = distance;
                    inputPosition.bufferIndex = i;
                }
            }
        }

        private void FindBestIn(List<Position> list, InputPosition inputPosition)
        {
            for (int i = 0; i < list.Count; i++)
            {
                double distance = StaticMath.Distance(inputPosition,list[i]);
                if (inputPosition.distance > distance)
                {
                    inputPosition.distance = distance;
                    inputPosition.bufferIndex = list[i].id;
                    inputPosition.positionStruct = list[i];
                }
            }

        }
    }
}