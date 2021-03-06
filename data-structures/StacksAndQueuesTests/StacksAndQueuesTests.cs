using StacksAndQueues.Classes;
using System;
using System.Text;
using Xunit;

namespace StacksAndQueuesTests
{
    public class StackTests
    {
        [Fact]
        public void CanInstantiateAnEmptyStack()
        {
            //Arrange
            Stack<string> testStack = new Stack<string>();

            //Assert
            Assert.Null(testStack.Top);
        }

        [Fact]
        public void CanPushSingleNodeOntoStack()
        {
            //Arrange
            Stack<string> testStack = new Stack<string>();
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
            Stack<string> testStack = new Stack<string>();
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
            Stack<string> testStack = new Stack<string>();
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
            Stack<string> testStack = new Stack<string>();

            //Assert
            Assert.Throws<NullReferenceException>(() => testStack.Pop());
        }

        [Fact]
        public void CanEmptyStackByPopping()
        {
            //Arrange
            Stack<string> testStack = new Stack<string>();
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
            Stack<string> testStack = new Stack<string>();
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
            Stack<string> testStack = new Stack<string>();

            //Assert
            Assert.Throws<NullReferenceException>(() => testStack.Peek());
        }

        [Fact]
        public void CanSeeIfEmptyStackIsEmpty()
        {
            //Arrange
            Stack<string> testStack = new Stack<string>();

            //Assert
            Assert.True(testStack.IsEmpty());
        }

        [Fact]
        public void CanSeeStackIsEmptyAfterPoppingEverything()
        {
            //Arrange
            Stack<string> testStack = new Stack<string>();
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
            Stack<string> testStack = new Stack<string>();
            string value1 = "the best node";

            //Act
            testStack.Push(value1);

            //Assert
            Assert.True(!testStack.IsEmpty());
        }
    }

    public class QueueTests
    {
        [Fact]
        public void CanInsantiateAnEmptyQueue()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();

            //Assert
            Assert.Null(testQueue.Front);
        }

        [Fact]
        public void CanEnqueueANode()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();
            string value1 = "the best node";

            //Act
            testQueue.Enqueue(value1);

            //Assert
            Assert.Equal(value1, testQueue.Front.Value);
        }

        [Fact]
        public void CanEnqueueMultipleNodes()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);

            //Assert
            Assert.Equal(value1, testQueue.Front.Value);
        }

        [Fact]
        public void CanDequeueANode()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            string dequeuedValue = testQueue.Dequeue();

            //Assert
            Assert.Equal(dequeuedValue, value1);
            Assert.Equal(value2, testQueue.Front.Value);
        }

        [Fact]
        public void CanDequeueMultipleNodes()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            testQueue.Dequeue();
            string testDequeueValue = testQueue.Dequeue();

            //Assert
            Assert.Equal(testDequeueValue, value2);
            Assert.Equal(value3, testQueue.Front.Value);
        }

        [Fact]
        public void ThrowsAnExceptionDequeuingEmptyQueue()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();

            //Assert
            Assert.Throws<NullReferenceException>(() => testQueue.Dequeue());
        }

        [Fact]
        public void CanPeekTheFrontNode()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            string peekedValue = testQueue.Peek();
            string dequeueValue = testQueue.Dequeue();

            //Assert
            Assert.Equal(value1, peekedValue);
            Assert.Equal(value1, dequeueValue);
        }

        [Fact]
        public void ThrowsAnExceptionPeekingAnEmptyQueue()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();

            //Assert
            Assert.Throws<NullReferenceException>(() => testQueue.Dequeue());
        }

        [Fact]
        public void CanSeeIfQueueIsEmptyAfterDequeuingEverything()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();
            string value1 = "the best node";
            string value2 = "nope, I am the best node";
            string value3 = "you're all wrong, I'm the best";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            testQueue.Dequeue();
            testQueue.Dequeue();
            testQueue.Dequeue();

            //Assert
            Assert.True(testQueue.IsEmpty());
        }

        [Fact]
        public void CanSeeEmptyQueueIsEmpty()
        {
            //Arrange
            Queue<string> testQueue = new Queue<string>();

            //Assert
            Assert.True(testQueue.IsEmpty());
        }
    }

    public class QueueGenericTests
    {
        [Fact]
        public void CanEnqueueStringBuilderObjects()
        {
            //Arrange
            Queue<StringBuilder> testQueue = new Queue<StringBuilder>();
            string string1 = "builder1";
            StringBuilder builder1 = new StringBuilder(string1);
            string string2 = "builder2";
            StringBuilder builder2 = new StringBuilder(string2);

            //Act
            testQueue.Enqueue(builder1);
            testQueue.Enqueue(builder2);

            //Assert
            Assert.Equal(string1, testQueue.Dequeue().ToString());
        }
    }
}