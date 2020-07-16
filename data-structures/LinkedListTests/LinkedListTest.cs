using System;
using Xunit;
using LLLibrary;

namespace LinkedListTest
{
    public class LinkedListTest
    {
        //Challenge 05 - Tests
        [Fact]
        public void CanInstantiateEmptyLinkedList()
        {
            LinkedList list = new LinkedList();
            Assert.Null(list.Head);
        }

        [Fact]
        public void CanInsertIntoLinkedList()
        {
            // insert means add to the front
            //Arrange
            LinkedList list = new LinkedList();
            list.Insert(4);
            Assert.Equal(4, list.Head.Value);
        }

        [Fact]
        public void CanInsertMultipleNodesInLinkedList()
        {
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            Assert.Equal(42, list.Head.Value);
        }

        [Fact]
        public void CanFindValueInList()
        {
            // arrange
            LinkedList list = new LinkedList();

            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            // Act 
            int searchForValue = 15;
            bool exists = list.Includes(searchForValue);

            // Assert
            Assert.True(exists);

        }

        [Fact]
        public void CannotFindValueInLinkedList()
        {
            // arrange
            LinkedList list = new LinkedList();

            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            // Act 
            int searchForValue = 100;
            bool exists = list.Includes(searchForValue);

            // Assert
            Assert.False(exists);
        }

        [Fact]
        public void CanReturnAllValuesInLinkedList()
        {
            // Arrange
            LinkedList list = new LinkedList();
            list.Insert(4);
            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            // Act
            string value = list.ToString();

            string expected = "42 -> 23 -> 16 -> 15 -> 8 -> 4 -> NULL";
            // Assert
            Assert.Equal(expected, value);
        }

        //CC - 06 - Append(), InsertBefore(), and InsertAfter()
        //Append()
        [Fact]
        public void CanAppendNode()
        {
            //Arrange
            LinkedList input = new LinkedList();
            input.Insert(4);
            input.Insert(8);
            input.Insert(15);

            //Act
            input.Append(11);

            //Assert
            Assert.Equal(11, input.Head.Next.Next.Next.Value);
        }

        [Fact]
        public void CanAppendMultipleNodes()
        {
            //Arrange
            LinkedList input = new LinkedList();
            input.Insert(4);
            input.Insert(8);
            input.Insert(15);

            //Act
            input.Append(11);
            input.Append(7);
            input.Append(35);

            //Assert
            Assert.Equal(11, input.Head.Next.Next.Next.Value);
            Assert.Equal(7, input.Head.Next.Next.Next.Next.Value);
            Assert.Equal(35, input.Head.Next.Next.Next.Next.Next.Value);
        }

        //InsertBefore()
        [Fact]
        public void CanInsertAtStartOfListUsingInsertBefore()
        {
            // Arrange
            LinkedList input = new LinkedList();
            input.Insert(4);
            input.Insert(8);
            input.Insert(15);
            input.Insert(16);
            input.Insert(23);
            input.Insert(42);

            //Act
            input.InsertBefore(42, 11);

            //Assert
            Assert.Equal(11, input.Head.Value);
        }

        [Fact]
        public void CanInsertInMiddleOfListUsingInsertBefore()
        {
            // Arrange
            LinkedList input = new LinkedList();
            input.Insert(4);
            input.Insert(8);
            input.Insert(15);
            input.Insert(16);
            input.Insert(23);
            input.Insert(42);

            //Act
            input.InsertBefore(16, 11);

            //Assert
            Assert.Equal(11, input.Head.Next.Next.Value);
        }

        [Fact]
        public void FailsToInsertUsingInsertBeforeWhenValueMissing()
        {
            // Arrange
            LinkedList input = new LinkedList();
            input.Insert(4);
            input.Insert(8);
            input.Insert(15);
            input.Insert(16);
            input.Insert(23);
            input.Insert(42);

            //Act
            input.InsertBefore(22, 11);

            //Assert
            Assert.True(!input.Includes(11));
        }

        //InsertAfter()
        [Fact]
        public void CanInsertInMiddleOfListUsingInsertAfter()
        {
            // Arrange
            LinkedList input = new LinkedList();
            input.Insert(4);
            input.Insert(8);
            input.Insert(15);
            input.Insert(16);
            input.Insert(23);
            input.Insert(42);

            //Act
            input.InsertAfter(16, 11);

            //Assert
            Assert.Equal(11, input.Head.Next.Next.Next.Value);
        }

        [Fact]
        public void CanInsertAtEndOfListUsingInsertAfter()
        {
            // Arrange
            LinkedList input = new LinkedList();
            input.Insert(8);
            input.Insert(16);
            input.Insert(23);
            input.Insert(42);

            //Act
            input.InsertAfter(8, 11);

            //Assert
            Assert.Equal(11, input.Head.Next.Next.Next.Next.Value);
        }

        [Fact]
        public void FailsToInsertUsingInsertAfterWhenValueMissing()
        {
            // Arrange
            LinkedList input = new LinkedList();
            input.Insert(4);
            input.Insert(8);
            input.Insert(15);
            input.Insert(16);
            input.Insert(23);
            input.Insert(42);

            //Act
            input.InsertAfter(7, 11);

            //Assert
            Assert.True(!input.Includes(11));
        }

        //Challenge 07 - Tests
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

        //Challenge 08 - Tests
        [Fact]
        public void CanZipTwoEqualLists()
        {
            //Arrange
            LinkedList list1 = new LinkedList();
            list1.Insert(4);
            list1.Insert(8);
            list1.Insert(15);
            list1.Insert(16);

            LinkedList list2 = new LinkedList();
            list2.Insert(11);
            list2.Insert(23);
            list2.Insert(9);
            list2.Insert(54);

            //Act
            Node result = LinkedList.ZipLists(list1, list2);

            //Assert
            Assert.Equal(8, result.Next.Next.Next.Next.Value);
        }

        [Fact]
        public void CanZipWhenOneListIsEmpty()
        {
            //Arrange
            LinkedList list1 = new LinkedList();

            LinkedList list2 = new LinkedList();
            list2.Insert(11);
            list2.Insert(23);
            list2.Insert(9);
            list2.Insert(54);

            //Act
            Node result = LinkedList.ZipLists(list1, list2);

            //Assert
            Assert.Equal(54, result.Value);
            Assert.Equal(11, result.Next.Next.Next.Value);
        }

        [Fact]
        public void CanZipUnequalLists()
        {
            //Arrange
            LinkedList list1 = new LinkedList();
            list1.Insert(4);
            list1.Insert(8);
            list1.Insert(15);

            LinkedList list2 = new LinkedList();
            list2.Insert(11);
            list2.Insert(23);
            list2.Insert(9);
            list2.Insert(54);
            list2.Insert(16);

            //Act
            Node result = LinkedList.ZipLists(list1, list2);

            //Assert
            Assert.Equal(9, result.Next.Next.Next.Next.Next.Value);
            Assert.Equal(11, result.Next.Next.Next.Next.Next.Next.Next.Value);
        }
    }
}