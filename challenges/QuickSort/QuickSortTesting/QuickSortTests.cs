using System;
using Xunit;
using QuickSortNameSpace;

namespace QuickSortTesting
{
    public class QuickSortTests
    {
        [Fact]
        public void CanSortAnEmptyArray()
        {
            //Arrange
            int[] testArray = new int[0];
            int[] expected = new int[0];

            //Act
            QuickSortClass.QuickSort(testArray);

            //Assert
            Assert.Equal(expected, testArray);
        }

        [Fact]
        public void CanSortAnArrayOfLengthOne()
        {
            //Arrange
            int[] testArray = new int[] { 5 };
            int[] expected = new int[] { 5 };

            //Act
            QuickSortClass.QuickSort(testArray);

            //Assert
            Assert.Equal(expected, testArray);
        }

        [Fact]
        public void CanSortAnArrayWithNegativeIntegers()
        {
            //Arrange
            int[] testArray = new int[] { 5, -12, 0, -22, 17, 9, -7 };
            int[] expected = new int[] { -22, -12, -7, 0, 5, 9, 17 };

            //Act
            QuickSortClass.QuickSort(testArray);

            //Assert
            Assert.Equal(expected, testArray);
        }

        [Theory]
        [InlineData(new int[] { 20, 18, 12, 8, 5, -2 }, new int[] { -2, 5, 8, 12, 18, 20 })]
        [InlineData(new int[] { 5, 12, 7, 5, 5, 7 }, new int[] { 5, 5, 5, 7, 7, 12 })]
        [InlineData(new int[] { 2, 3, 5, 7, 13, 11 }, new int[] { 2, 3, 5, 7, 11, 13 })]
        [InlineData(new int[] { 8, 4, 23, 42, 16, 15 }, new int[] { 4, 8, 15, 16, 23, 42 })]
        public void CanSortArray(int[] input, int[] expected)
        {
            //Act
            QuickSortClass.QuickSort(input);

            //Assert
            Assert.Equal(expected, input);
        }
    }
}
