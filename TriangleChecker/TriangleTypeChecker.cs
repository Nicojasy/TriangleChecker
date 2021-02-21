using System;
using System.Linq;

namespace TriangleChecker
{
    public static class TriangleTypeChecker
    {
        public enum TriangleType
        {
            Acute,
            Obtuse,
            Rectangular
        }

        public static TriangleType CheckTriangleType(params double[] sides)
        {
            if (sides.Length != 3)
                throw new ArgumentException("The number of sides is not 3");

            if (sides.Any(s => Math.Sign(s) == -1))
                throw new ArgumentException("Parties cannot be negative");

            Array.Sort(sides);

            if (sides[2] >= sides[1] + sides[0])
                throw new Exception("The triangle does not exist");

            var result = Decimal.Subtract((decimal)(sides[0] * sides[0] + sides[1] * sides[1]),
                                          (decimal)(sides[2] * sides[2]));

            if (result == 0)
                return (TriangleType)2;
            else
                return result > 0 ?
                    (TriangleType)0 : (TriangleType)1;
        }
    }
}
