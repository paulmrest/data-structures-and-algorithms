using System;

namespace StacksAndQueues.Classes
{
    public class Queue<T>
    {
        public Node<T> Front { get; set; }

        private Node<T> Rear { get; set; }

        /// <summary>
        /// Enqueues a new Node containing the parameter value at the back of the queue.
        /// </summary>
        /// <param name="value">
        /// string: the value for the node to be enqueued
        /// </param>
        public void Enqueue(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (Front == null)
            {
                Front = newNode;
                Rear = newNode;
            }
            else
            {
                Rear.Next = newNode;
                Rear = newNode;
            }
        }

        /// <summary>
        /// Dequeues a node from the queue and returns its value.
        /// </summary>
        /// <returns>
        /// string: the string value of the dequeued Node
        /// </returns>
        public T Dequeue()
        {
            try
            {
                Node<T> temp = Front;
                Front = Front.Next;
                return temp.Value;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the value of the front Node without modifying the queue.
        /// </summary>
        /// <returns>
        /// string: the value of the front Node
        /// </returns>
        public T Peek()
        {
            try
            {
                T frontValue = Front.Value;
                return frontValue;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a bool, true if the queue is empty, false if not.
        /// </summary>
        /// <returns>
        /// bool: true if the queue is empty, false if not
        /// </returns>
        public bool IsEmpty()
        {
            return Front == null;
        }
    }
}
