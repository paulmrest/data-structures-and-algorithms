using System;
using Xunit;
using LLLibrary;

namespace LinkedListKthFromEndTest
{
    public class LinkedListKthFromEndTests
    {
        [Fact]
        public void KGreaterThanLinkedListLengthTest()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            int input = 6;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.KthFromEnd(input));
        }

        [Fact]
        public void KEqualToLinkedListLengthTest()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            int expected = 42;

            //Act
            int result = list.KthFromEnd(5);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void KIsNegativeTest()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            int input = -1;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.KthFromEnd(input));
        }

        [Fact]
        public void LinkedListSizeOneTest()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(4);

            int expected = 4;

            //Act
            int result = list.KthFromEnd(0);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void KInMiddleOfLinkedListTest()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            int expected = 16;

            //Act
            int result = list.KthFromEnd(3);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EmptyLinkedListTest()
        {
            // Arrange
            LinkedList list = new LinkedList();

            int input = 2;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.KthFromEnd(input));
        }
    }
}
