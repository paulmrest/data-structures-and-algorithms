using System;
using System.Collections.Generic;
using System.Text;

namespace HashTables.Classes
{
    public class KeyValueNode<T>
    {
        public string Key { get; set; }

        public T Value { get; set; }

        /// <summary>
        /// Instantiates a new KeyValueNode.
        /// </summary>
        /// <param name="key">
        /// string: a key to be correlated with the value
        /// </param>
        /// <param name="value">
        /// <T>: a value to be correlated with key
        /// </param>
        public KeyValueNode(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}
