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

        public PseudoQueue()
        {
			StackOne = new Stack();
			StackTwo = new Stack();
			Count = 0;
			StackOneLastPopped = false;
        }

		public void Enqueue(string value)
        {
			int depth = Count / 2;
			Stack shuffledStack = Count % 2 == 0 ? StackOne : StackTwo;
			Stack temp = new Stack();
			for (int i = 0; i < depth; i++)
			{
				temp.Push(shuffledStack.Pop());
			}
			shuffledStack.Push(value);
			for (int j = 0; j < depth; j++)
			{
				shuffledStack.Push(temp.Pop());
			}
			Count++;
        }

		public string Dequeue()
        {
			try
            {
                string returnValue;
                if (StackOneLastPopped)
                {
					StackOneLastPopped = !StackOneLastPopped;
                    returnValue = StackTwo.Pop();
                }
                else
                {
					StackOneLastPopped = !StackOneLastPopped;
					returnValue = StackOne.Pop();
                }
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
