using System.Text;

namespace StacksAndQueues.Classes
{
    public class Node
    {
        public string Value { get; set; }

        public Node Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class with the parameter string as its value.
        /// </summary>
        /// <param name="value">
        /// string: the value for the Node to contain
        /// </param>
        public Node(string value)
        {
            Value = value;
            StringBuilder builder = new StringBuilder();
        }
    }
}
