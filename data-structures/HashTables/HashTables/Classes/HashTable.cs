using System;
using HashTables.Classes;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace HashTables
{
    public class HashTable<T>
    {
        //This is only public for testing. This should be private.
        public LinkedList<KeyValueNode<T>>[] HashMap;

        public int Count { get; set; }

        private int _defaultStartingSize = 20;

        /// <summary>
        /// Instantiates a new HashTable of the default size, 20.
        /// </summary>
        /// <param name="size">
        /// int: the size of the HashTable
        /// </param>
        public HashTable()
        {
            HashMap = new LinkedList<KeyValueNode<T>>[_defaultStartingSize];
            Count = 0;
        }

        /// <summary>
        /// Instantiates a new HashTable of the parameter size.
        /// </summary>
        /// <param name="size">
        /// int: the size of the HashTable
        /// </param>
        public HashTable(int size)
        {
            HashMap = new LinkedList<KeyValueNode<T>>[size];
            Count = 0;
        }

        /// <summary>
        /// Adds a new key-value pair to the HashTable. Note that presently this does not increase the size of the HashTable.
        /// </summary>
        /// <param name="key">
        /// string: a key value
        /// </param>
        /// <param name="value">
        /// <T>: the value to be correlated to the key
        /// </param>
        public void Add(string key, T value)
        {
            CheckHashMapSize();
            int index = GetHash(key);
            KeyValueNode<T> newNode = new KeyValueNode<T>(key, value);
            if (HashMap[index] == null)
            {
                HashMap[index] = new LinkedList<KeyValueNode<T>>();
            }
            HashMap[index].AddLast(newNode);
            Count++;
        }

        /// <summary>
        /// Gets the corresponding value<T> for the parameter key.
        /// </summary>
        /// <param name="key">
        /// string: the corresponding key for the value<T>
        /// </param>
        /// <returns>
        /// value<T>: if key exists, the value for the parameter key; if key does not exists, returns the default value for the Type <T>
        /// </returns>
        public T Get(string key)
        {
            int index = GetHash(key);
            if (HashMap[index] != null)
            {
                if (HashMap[index].Count == 1)
                {
                    return HashMap[index].First.Value.Value;
                }
                LinkedListNode<KeyValueNode<T>> currNode = HashMap[index].First;
                while (currNode != null)
                {
                    if (currNode.Value.Key == key)
                    {
                        return currNode.Value.Value;
                    }
                    currNode = currNode.Next;
                }
            }
            //This is not ideal. For non-nullable types like int, this will return a legit value.
            return default;
        }

        /// <summary>
        /// Returns a boolean indicating whether a given key is present in the HashTable.
        /// </summary>
        /// <param name="key">
        /// string: a key
        /// </param>
        /// <returns>
        /// bool: true if the key is present in the Hashtable, false otherwise
        /// </returns>
        public bool Contains(string key)
        {
            int index = GetHash(key);
            if (HashMap[index] != null)
            {
                LinkedListNode<KeyValueNode<T>> currNode = HashMap[index].First;
                while (currNode != null)
                {
                    if (currNode.Value.Key == key)
                    {
                        return true;
                    }
                    currNode = currNode.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Public for testing. This should be private.
        /// Generates a hash value from the parameter key. Will always generate the same hash for a given input.
        /// </summary>
        /// <param name="key">
        /// string: a key to be hashed
        /// </param>
        /// <returns>
        /// int: a hash value such that > 0 and < HashMap.Length
        /// </returns>
        public int GetHash(string key)
        {
            int totalASCIIValue = 0;
            for (int i = 0; i < key.Length; i++)
            {
                totalASCIIValue += key[i];
            }
            int primeProduct = totalASCIIValue * 887;
            return primeProduct % HashMap.Length;
        }

        /// <summary>
        /// Checks if Count is greater than 3/4 the size of HashMap.Length, and if it is, doubles the size of HashMap, remapping all elements.
        /// </summary>
        private void CheckHashMapSize()
        {
            if (Count > (HashMap.Length * 0.75))
            {
                LinkedList<KeyValueNode<T>>[] oldHashMap = HashMap;
                HashMap = new LinkedList<KeyValueNode<T>>[HashMap.Length * 2];
                Count = 0;
                foreach (LinkedList<KeyValueNode<T>> oneLL in oldHashMap)
                {
                    if (oneLL != null)
                    {
                        LinkedListNode<KeyValueNode<T>> currNode = oneLL.First;
                        while (currNode != null)
                        {
                            Add(currNode.Value.Key, currNode.Value.Value);
                            currNode = currNode.Next;
                        }
                    }
                }
            }
        }
    }
}
