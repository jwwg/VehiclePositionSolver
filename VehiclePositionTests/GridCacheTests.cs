using GeoCoordinatePortable;
using VehiclePositionSolver;
using VehiclePositionSolver.GridCache;

namespace VehiclePositionTests
{
    public class Tests
    {

        [Test]
        public void Test_LatitudeMultiplier()
        {
            GridCache gridCache = new GridCache(3);
            Position position = new Position(-1, 34.544909f, 0);
            Assert.AreEqual(1000000, gridCache.latMultiplier); 
            long actual = gridCache.ToCache(position);

            //34+90 = 124,544,
            //0+180=          180,000
            //     =  124,544,180,000
            //        124,544,180,000
            Assert.AreEqual(124545180000, actual);
        }

        [Test]
        public void Test_LatitudeOnlyMultiplier()
        {
            GridCache gridCache = new GridCache(3);
            long actual = gridCache.ToCachePart(34.544909 + 90, 1000000);
            Assert.AreEqual(124545000000, actual);
        }

        [Test]
        public void Test_LongOnlyMultiplier()
        {
            GridCache gridCache = new GridCache(3);
            long actual = gridCache.ToCachePart(-102.1015091 + 180, 1);
            Assert.AreEqual(77898, actual);
        }

        [Test]
        public void Test_CacheLookup()
        {
            GridCache gridCache = new GridCache(3);
            Position positionStruct = new Position(0, 34.544909f, -102.1015091f);
            gridCache.Add(positionStruct);
            Assert.IsTrue(gridCache.HasEntries(positionStruct)); 
        }

        [Test]
        public void Test_CacheLookupMultiples()
        {
            GridCache gridCache = new GridCache(3);
            Position positionStruct = new Position(0, 34.544909f, -102.1015091f);
            gridCache.Add(positionStruct);
            gridCache.Add(positionStruct);
            List<Position>? positions = gridCache.At(positionStruct);
            Assert.IsNotNull(positions);
            Assert.AreEqual(2, positions.Count);
        }

        [Test]
        public void Test_Decompose()
        {
            GridCache gridCache = new GridCache(3);
            Position geoCoordinate = new Position(-1,34.544909f, -102.101509f);
            long coord = gridCache.ToCache(geoCoordinate);
            (long latitude, long longitude) = gridCache.Decompose(coord);
            Assert.AreEqual(124545 , latitude);
            Assert.AreEqual(77898, longitude);
        }


    }
}