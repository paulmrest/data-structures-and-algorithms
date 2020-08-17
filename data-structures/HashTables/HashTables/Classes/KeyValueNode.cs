using System;
using System.Collections.Generic;
using System.Text;

namespace HashTables.Classes
{
    public class KeyValueNode<T>
    {
        public string Key { get; set; }

        public T Value { get; set; }

        public KeyValueNode(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}
