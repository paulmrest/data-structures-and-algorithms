using System;
using HashTables;
using HashTables.Classes;

namespace LeftJoin
{
    public class LeftJoin
    {
        public static string[,] LeftJoinHashTables(HashTable<string> tableOne, HashTable<string> tableTwo)
        {
            string[,] leftJoin = new string[tableOne.HashMap.Length, 3];
            int rowIndex = 0;
            for (int i = 0; i < tableOne.HashMap.Length; i++)
            {
                if (tableOne.HashMap[i] != null)
                {
                    var currNode = tableOne.HashMap[i].First;
                    while (currNode != null)
                    {
                        leftJoin[rowIndex, 0] = currNode.Value.Key;
                        leftJoin[rowIndex, 1] = currNode.Value.Value;
                        if (tableTwo.Contains(currNode.Value.Key))
                        {
                            leftJoin[rowIndex, 2] = tableTwo.Get(currNode.Value.Key);
                        }
                        else
                        {
                            leftJoin[rowIndex, 2] = "";
                        }
                        currNode = currNode.Next;
                        rowIndex++;
                    }
                }
            }
            return leftJoin;
        }
    }
}
