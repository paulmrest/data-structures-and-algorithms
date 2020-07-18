using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueues.Classes
{
    public class Node
    {
        public string Value { get; set; }

        public Node Next { get; set; }

        public Node(string value)
        {
            Value = value;
        }
    }
}
