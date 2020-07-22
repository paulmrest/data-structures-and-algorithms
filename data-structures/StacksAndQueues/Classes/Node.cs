using System.Text;

namespace StacksAndQueues.Classes
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class with the parameter string as its value.
        /// </summary>
        /// <param name="value">
        /// string: the value for the Node to contain
        /// </param>
        public Node(T value)
        {
            Value = value;
            StringBuilder builder = new StringBuilder();
        }
    }
}
