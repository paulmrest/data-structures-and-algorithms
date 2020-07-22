using System;

namespace StacksAndQueues.Classes
{
    public class Stack<T>
    {
        public Node<T> Top { get; set; }

        /// <summary>
        /// Adds a new Node to the top of the stack with the parameter value.
        /// </summary>
        /// <param name="value">
        /// string: the value to be contained in the new Node
        /// </param>
        public void Push(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = Top;
            Top = newNode;
        }

        /// <summary>
        /// Pops the top Node off the stack and returns its value.
        /// </summary>
        /// <returns>
        /// string: the string value in the top Node on the stack
        /// </returns>
        public T Pop()
        {
            try
            {
                Node<T> temp = Top;
                Top = Top.Next;
                return temp.Value;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns the value contained in the Node at the top of the stack without removing the node.
        /// </summary>
        /// <returns>
        /// string: the value of the top Node in the stack
        /// </returns>
        public T Peek()
        {
            try
            {
                T value = Top.Value;
                return value;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a bool, true if the stack is empty, false if not.
        /// </summary>
        /// <returns>
        /// bool: true if stack is empty, false if not
        /// </returns>
        public bool IsEmpty()
        {
            return Top == null;
        }
    }
}
