using System;
using System.Runtime.InteropServices;
using StacksAndQueues.Classes;

namespace QueuesWithStacks
{
    public class PseudoQueue
    {
        private Stack StackOne { get; set; }

        private Stack StackTwo { get; set; }

        private int Count { get; set; }

        private bool StackOneLastPopped { get; set; }

		/// <summary>
		/// Instantiates a new PseudoQueue object.
		/// </summary>
        public PseudoQueue()
        {
			StackOne = new Stack();
			StackTwo = new Stack();
			Count = 0;
			StackOneLastPopped = false;
        }

        /// <summary>
        /// Enqueues a new Node containing the parameter value at the back of the queue.
        /// </summary>
        /// <param name="value">
        /// string: the value for the node to be enqueued
        /// </param>
		public void Enqueue(string value)
		{
			int depth = Count / 2;
			Stack shuffledStack = Count % 2 == 0 ? StackOne : StackTwo;
			Stack tempStorageStack = Count % 2 != 0 ? StackOne : StackTwo;
			for (int i = 0; i < depth; i++)
			{
				tempStorageStack.Push(shuffledStack.Pop());
			}
			shuffledStack.Push(value);
			for (int j = 0; j < depth; j++)
			{
				shuffledStack.Push(tempStorageStack.Pop());
			}
			Count++;
		}

        /// <summary>
        /// Dequeues a node from the queue and returns its value.
        /// </summary>
        /// <returns>
        /// string: the string value of the dequeued Node
        /// </returns>
        public string Dequeue()
        {
			try
            {
                string returnValue = StackOneLastPopped ? StackTwo.Pop() : StackOne.Pop();
                StackOneLastPopped = !StackOneLastPopped;
                Count--;
                return returnValue;
            } 
			catch (NullReferenceException e)
            {
				throw e;
            }
        }
	}
}
