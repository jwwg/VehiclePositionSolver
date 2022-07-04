using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePositionSolver.Solver
{
    internal static class StaticMath
    {
        public static double Distance(InputPosition from, Position other)
        {
            double num4 = other.longitudeRadians - from.longitudeRadians;
            double num5 = Math.Pow(Math.Sin((other.latitudeRadians - from.latitudeRadians) / 2.0), 2.0) +
                Math.Cos(from.latitudeRadians) * Math.Cos(other.latitudeRadians) * Math.Pow(Math.Sin(num4 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5)));
        }

        public static double SquareDistance(InputPosition from, Position other)
        {
            float x = from.longitude - other.longitude;
            float y = from.latitude - other.latitude;
            return x * x + y * y;
        }


    }
}
