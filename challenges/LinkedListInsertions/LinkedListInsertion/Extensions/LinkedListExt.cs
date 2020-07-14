using LLLibrary;

namespace Linked_Lists.Extensions
{
    public static class LinkedListExt
    {
        /// <summary>
        /// Appends a new node containing the integer value at the end of the linked list.
        /// </summary>
        /// <param name="list">
        /// The linked list this method is invoked against (extending the class)
        /// </param>
        /// <param name="value">
        /// integer: value for the appended node
        /// </param>
        public static void Append(this LinkedList list, int value)
        {
            Node currLoopNode = list.Head;
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
        /// <param name="list">
        /// The linked list this method is invoked against (extending the class)
        /// </param>
        /// <param name="value">
        /// integer: the value to search for in a node
        /// </param>
        /// <param name="newValue">
        /// integer: the newValue contained in the new node
        /// </param>

        public static void InsertBefore(this LinkedList list, int value, int newValue)
        {
            Node prevNode = null;
            Node currLoopNode = list.Head;
            while (currLoopNode != null)
            {
                if (currLoopNode.Value == value)
                {
                    Node newNode = new Node(newValue);
                    if (prevNode == null)
                    {
                        list.Head = newNode;
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
        /// <param name="list">
        /// The linked list this method is invoked against (extending the class)
        /// </param>
        /// <param name="value">
        /// integer: the value to search for in a node
        /// </param>
        /// <param name="newValue">
        /// integer: the newValue contained in the new node
        /// </param>
        public static void InsertAfter(this LinkedList list, int value, int newValue)
        {
            int count = 0;
            Node currLoopNode = list.Head;
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
    }
}