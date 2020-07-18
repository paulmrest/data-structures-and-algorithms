using StacksAndQueues.Classes;
using System;
using System.Reflection.PortableExecutable;
using Xunit;

namespace StacksAndQueuesTests
{
    public class StacksAndQueuesTests
    {
        #region StackTesting
        [Fact]
        public void CanPushSingleNodeOntoStack()
        {
            //Arrange
            Stack testStack = new Stack();
            string value = "the best node";

            //Act
            testStack.Push(value);

            //Assert
            Assert.Equal(value, testStack.Top.Value);
        }

        [Fact]
        public void CanPushMultipleValuesOntoStack()
        {
            //Arrange
            Stack testStack = new Stack();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testStack.Push(value1);
            testStack.Push(value2);
            testStack.Push(value3);

            //Assert
            Assert.Equal(value3, testStack.Top.Value);
        }

        [Fact]
        public void CanPopOffSack()
        {
            //Arrange
            Stack testStack = new Stack();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testStack.Push(value1);
            testStack.Push(value2);
            testStack.Push(value3);
            string poppedValue = testStack.Pop();

            //Assert
            Assert.Equal(value3, poppedValue);
        }

        [Fact]
        public void ThrowsExceptionPoppingEmptyStack()
        {
            //Arrange
            Stack testStack = new Stack();

            //Assert
            Assert.Throws<NullReferenceException>(() => testStack.Pop());
        }

        [Fact]
        public void CanEmptyStackByPopping()
        {
            //Arrange
            Stack testStack = new Stack();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testStack.Push(value1);
            testStack.Push(value2);
            testStack.Push(value3);
            testStack.Pop();
            testStack.Pop();
            testStack.Pop();

            //Assert
            Assert.Null(testStack.Top);
            Assert.Throws<NullReferenceException>(() => testStack.Pop());
        }

        [Fact]
        public void CanPeekAtStack()
        {
            //Arrange
            Stack testStack = new Stack();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testStack.Push(value1);
            testStack.Push(value2);
            testStack.Push(value3);
            string peekedValue = testStack.Peek();

            //Assert
            Assert.Equal(peekedValue, testStack.Top.Value);
            Assert.Equal(value3, testStack.Top.Value);
        }

        [Fact]
        public void ThrowsExceptionPeekingEmptyStack()
        {
            //Arrange
            Stack testStack = new Stack();

            //Assert
            Assert.Throws<NullReferenceException>(() => testStack.Peek());
        }

        [Fact]
        public void CanSeeIfEmptyStackIsEmpty()
        {
            //Arrange
            Stack testStack = new Stack();

            //Assert
            Assert.True(testStack.IsEmpty());
        }

        [Fact]
        public void CanSeeStackIsEmptyAfterPoppingEverything()
        {
            //Arrange
            Stack testStack = new Stack();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testStack.Push(value1);
            testStack.Push(value2);
            testStack.Push(value3);
            testStack.Pop();
            testStack.Pop();
            testStack.Pop();

            //Assert
            Assert.True(testStack.IsEmpty());
        }


        [Fact]
        public void CanSeeIfStackIsNotEmpty()
        {
            //Arrange
            Stack testStack = new Stack();
            string value1 = "the best node";

            //Act
            testStack.Push(value1);

            //Assert
            Assert.True(!testStack.IsEmpty());
        }
        #endregion
    }
}
