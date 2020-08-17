using System;
using HashTables.Classes;
using System.Collections.Generic;

namespace HashTables
{
    public class HashTable<T>
    {
        //This is only public for testing. This should be private.
        public LinkedList<KeyValueNode<T>>[] HashMap;

        public HashTable(int size)
        {
            HashMap = new LinkedList<KeyValueNode<T>>[size];
        }


        public void Add(string key, T value)
        {
            int index = GetHash(key);
            KeyValueNode<T> newNode = new KeyValueNode<T>(key, value);
            if (HashMap[index] == null)
            {
                HashMap[index] = new LinkedList<KeyValueNode<T>>();
            }
            HashMap[index].AddLast(newNode);
        }


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
        /// 
        /// </param>
        /// <returns></returns>
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
    }
}
