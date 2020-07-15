using System;
using Xunit;
using LLLibrary;

namespace LinkedListInsertionTest
{
    public class LinkedListExtTests
    {
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
    }
}
