using System;
using Xunit;
using QueuesWithStacks;

namespace QueuesWithStacksTesting
{
    public class QueuesWithStacksTests
    {
        [Fact]
        public void CanEnqueueAnOddNumberOfValues()
        {
            //Arrange
            PseudoQueue testQueue = new PseudoQueue();
            string value1 = "1";
            string value2 = "2";
            string value3 = "3";
            string value4 = "4";
            string value5 = "5";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            testQueue.Enqueue(value4);
            testQueue.Enqueue(value5);

            //Assert
            Assert.Equal(value1, testQueue.Dequeue());
        }

        [Fact]
        public void CanEnqueueAnEvenNumberOfValues()
        {
            //Arrange
            PseudoQueue testQueue = new PseudoQueue();
            string value1 = "1";
            string value2 = "2";
            string value3 = "3";
            string value4 = "4";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            testQueue.Enqueue(value4);

            //Assert
            Assert.Equal(value1, testQueue.Dequeue());
        }

        [Fact]
        public void CanDequeueMultipleValues()
        {
            //Arrange
            PseudoQueue testQueue = new PseudoQueue();
            string value1 = "1";
            string value2 = "2";
            string value3 = "3";
            string value4 = "4";
            string value5 = "5";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            testQueue.Enqueue(value4);
            testQueue.Enqueue(value5);

            testQueue.Dequeue();
            testQueue.Dequeue();
            testQueue.Dequeue();
            testQueue.Dequeue();

            //Assert
            Assert.Equal(value5, testQueue.Dequeue());
        }

        [Fact]
        public void CanDequeueThenEnqueueThenDequeue()
        {
            //Arrange
            PseudoQueue testQueue = new PseudoQueue();
            string value1 = "1";
            string value2 = "2";
            string value3 = "3";
            string value4 = "4";
            string value5 = "5";

            //Act
            testQueue.Enqueue(value1);
            testQueue.Enqueue(value2);
            testQueue.Enqueue(value3);
            testQueue.Enqueue(value4);
            testQueue.Enqueue(value5);

            testQueue.Dequeue();
            testQueue.Dequeue();
            testQueue.Dequeue();

            string value6 = "6";
            string value7 = "7";
            testQueue.Enqueue(value6);
            testQueue.Enqueue(value7);

            //Assert
            Assert.Equal(value4, testQueue.Dequeue());
        }

        [Fact]
        public void DequeuingAnEmptyQueueThrowsException()
        {
            //Arrange
            PseudoQueue testQueue = new PseudoQueue();

            //Assert
            Assert.Throws<NullReferenceException>(() => testQueue.Dequeue());
        }
    }
}
