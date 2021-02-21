using System;
using Xunit;
using TriangleChecker;

namespace TriangleCheckerXUnitTest
{
    public class TriangleTypeCheckerTests
    {
        [Theory]
        [InlineData(4.0, 6.0, 7.0)]
        [InlineData(13.002, 15.754, 14.325)]
        public void AcuteAngledTest(params double[] sides)
        {
            Assert.Equal((TriangleTypeChecker.TriangleType)0, TriangleTypeChecker.CheckTriangleType(sides));
        }

        [Theory]
        [InlineData(2.0, 4.0, 3.0)]
        [InlineData(5.989, 6.999, 2.899)]
        public void ObtusenessTest(params double[] sides)
        {
            Assert.Equal((TriangleTypeChecker.TriangleType)1, TriangleTypeChecker.CheckTriangleType(sides));
        }

        [Theory]
        [InlineData(3.0, 4.0, 5.0)]
        [InlineData(300.003, 400.004, 500.005)]
        public void SquarenessTest(params double[] sides)
        {
            Assert.Equal((TriangleTypeChecker.TriangleType)2, TriangleTypeChecker.CheckTriangleType(sides));
        }

        [Theory]
        [InlineData(3.454, 4.234)]
        [InlineData(7.0, 6.0, 5.0, 4.0)]
        public void CallArrayLengthErrorTest(params double[] sides)
        {
            var exception = Assert.Throws<ArgumentException>(() => TriangleTypeChecker.CheckTriangleType(sides));

            Assert.Equal("The number of sides is not 3", exception.Message);
        }

        [Theory]
        [InlineData(-2.0, 3.0, 4.0)]
        [InlineData(3.325, 4.474, -5.876)]
        public void CallArrayNegativeNumberErrorTest(params double[] sides)
        {
            var exception = Assert.Throws<ArgumentException>(() => TriangleTypeChecker.CheckTriangleType(sides));

            Assert.Equal("Parties cannot be negative", exception.Message);
        }
        
        [Theory]
        [InlineData(7.0, 3.0, 4.0)]
        [InlineData(3.949, 4.949, 10.352)]
        public void CallErrorWhereTriangleIsNotTriangleTest(params double[] sides)
        {
            Exception exception = Assert.Throws<Exception>(() => TriangleTypeChecker.CheckTriangleType(sides));

            Assert.Equal("The triangle does not exist", exception.Message);
        }
    }
}
