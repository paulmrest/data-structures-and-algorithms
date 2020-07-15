using System;
using System.Collections.Generic;
using System.Text;

namespace LLLibrary
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Current { get; set; }

        public LinkedList()
        {
            Head = null;
            Current = Head;
        }

        /// <summary>
        /// Inserts a new node with an O(1) operation into linkedList
        /// </summary>
        /// <param name="value">value to be strored in the node</param>
        public void Insert(int value)
        {
            Current = Head;
            // create teh new node that needs to be added
            Node node = new Node(value);
            node.Next = Head;
            Head = node;
        }

        /// <summary>
        /// Finds a specific value in the linked list
        /// O(n) time efficiency
        /// </summary>
        /// <param name="value">searchable value</param>
        /// <returns>response if it exists</returns>
        public bool Includes(int value)
        {
            Current = Head;
            // While loop
            // traverse the linked list and do the comparison
            while (Current != null)
            {
                // check if it's equal to the given value
                if (Current.Value == value)
                {
                    return true;
                }

                // move to the next one
                Current = Current.Next;
            }

            return false;
        }

        /// <summary>
        /// Overriding current behavior of tostring method to output all values in the linked list as a string 
        /// </summary>
        /// <returns>a string containing all the values of the linked list</returns>
        public override string ToString()
        {
            Current = Head;
            // StringBuilder class. 
            // why would you use Stringbuilder over string concatination??

            StringBuilder sb = new StringBuilder();

            // start constructing sb
            while (Current != null)
            {
                sb.Append($"{Current.Value} -> ");
                Current = Current.Next;
            }

            sb.Append("NULL");

            return sb.ToString();
        }

        /// <summary>
        /// Appends a new node containing the integer value at the end of the linked list.
        /// </summary>
        /// <param name="value">
        /// integer: value for the appended node
        /// </param>
        public void Append(int value)
        {
            Node currLoopNode = Head;
            while (currLoopNode.Next != null)
            {
                currLoopNode = currLoopNode.Next;
            }
            Node newNode = new Node(value);
            currLoopNode.Next = newNode;
        }

        /// <summary>
        /// Inserts a new node containing integer newValue before the first node containing integer value, if any exist.
        /// </summary>
        /// <param name="value">
        /// integer: the value to search for in a node
        /// </param>
        /// <param name="newValue">
        /// integer: the newValue contained in the new node
        /// </param>
        public void InsertBefore(int value, int newValue)
        {
            Node prevNode = null;
            Node currLoopNode = Head;
            while (currLoopNode != null)
            {
                if (currLoopNode.Value == value)
                {
                    Node newNode = new Node(newValue);
                    if (prevNode == null)
                    {
                        Head = newNode;
                        newNode.Next = currLoopNode;
                        break;
                    }
                    else
                    {
                        prevNode.Next = newNode;
                        newNode.Next = currLoopNode;
                        break;
                    }
                }
                prevNode = currLoopNode;
                currLoopNode = currLoopNode.Next;
            }
        }

        /// <summary>
        /// Inserts a new node containing integer newValue after the first node containing integer value, if any exist.
        /// </summary>
        /// <param name="value">
        /// integer: the value to search for in a node
        /// </param>
        /// <param name="newValue">
        /// integer: the newValue contained in the new node
        /// </param> 
        public void InsertAfter(int value, int newValue)
        {
            int count = 0;
            Node currLoopNode = Head;
            while (currLoopNode != null)
            {
                if (currLoopNode.Value == value)
                {
                    Node newNode = new Node(newValue);
                    if (count == 0)
                    {
                        currLoopNode.Next = newNode;
                        break;
                    }
                    else
                    {
                        Node temp = currLoopNode.Next;
                        currLoopNode.Next = newNode;
                        newNode.Next = temp;
                        break;
                    }
                }
                count++;
                currLoopNode = currLoopNode.Next;
            }
        }

        /// <summary>
        /// Finds the Kth node from the end of the list, and returns that node's value. K = 0 is the end of the list.
        /// </summary>
        /// <param name="k">
        /// int: the Kth node from the end
        /// </param>
        /// <returns>
        /// int: the Kth node's value
        /// </returns>
        public int KthFromEnd(int k)
        {
            if (k < 0 || Head == null)
            {
                throw new ArgumentOutOfRangeException("KthFromEnd needs a positive value.");
            }
            int count = 0;
            Node currLoopNode = Head;
            while (currLoopNode != null)
            {
                count++;
                currLoopNode = currLoopNode.Next;
            }
            if (k >= count)
            {
                throw new ArgumentOutOfRangeException("Linked list not long enough for parameter k value.");
            }
            int kDiff = count - k;
            currLoopNode = Head;
            while (currLoopNode != null)
            {
                if (kDiff == 1)
                {
                    return currLoopNode.Value;
                }
                kDiff--;
                currLoopNode = currLoopNode.Next;
            }
            return -1;
        }
    }
}
