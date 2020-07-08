using System;
using Xunit;
using static ArrayShift.Program;

namespace ArrayShiftTest
{
    public class ArrayShiftTest
    {
        [Fact]
        public void InsertAndShiftEvenTest()
        {
            Assert.Equal(new int[] { 2, 4, 5, 6, 8 }, InsertShiftArray(new int[] { 2, 4, 6, 8 }, 5));
        }

        [Fact]
        public void InsertAndShiftOddTest()
        {
            Assert.Equal(new int[] { 4, 8, 15, 16, 23, 42 }, InsertShiftArray(new int[] { 4, 8, 15, 23, 42 }, 16));
        }

        [Fact]
        public void InsertAndShiftZeroLengthArrayTest()
        {
            Assert.Equal(new int[] { 14 }, InsertShiftArray(new int[0], 14));
        }

        [Fact]
        public void InsertAndShiftArrayLengthOneTest()
        {
            Assert.Equal(new int[] { 17, 3 }, InsertShiftArray(new int[] { 17 }, 3));
        }
    }
}
