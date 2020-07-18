using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueues.Classes
{
    public class Stack
    {
        public Node Top { get; set; }

        /// <summary>
        /// Adds a new node to the top of the stack with the parameter value.
        /// </summary>
        /// <param name="value">
        /// string: the value to be contined in the new node
        /// </param>
        public void Push(string value)
        {
            Node newNode = new Node(value);
            newNode.Next = Top;
            Top = newNode;
        }

        /// <summary>
        /// Pops the top node off the stack and returns its value.
        /// </summary>
        /// <returns>
        /// string: the string value in the top node on the stack
        /// </returns>
        public string Pop()
        {
            try
            {
                Node temp = Top;
                Top = Top.Next;
                return temp.Value;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public string Peek()
        {
            try
            {
                string value = Top.Value;
                return value;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public bool IsEmpty()
        {
            return Top == null;
        }
    }
}
