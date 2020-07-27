using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Classes
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        /// <summary>
        /// Instantiates a new Node object with <T> value.
        /// </summary>
        /// <param name="value">
        /// T: a value for the node
        /// </param>
        public Node(T value)
        {
            Value = value;
        }
    }
}
