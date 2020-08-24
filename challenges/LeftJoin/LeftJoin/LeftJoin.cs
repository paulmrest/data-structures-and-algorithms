using System;
using HashTables;
using HashTables.Classes;
using LeftJoin.Classes;

namespace LeftJoin
{
    public class LeftJoin
    {
        /// <summary>
        /// Left joins two HashTable<string> objects.
        /// </summary>
        /// <param name="leftTable">
        /// HashTable<string>: the HashTable<string> to be used as the left table in the left join
        /// </param>
        /// <param name="rightTable">
        /// HashTable<string>: the HashTable<string> to be used as the right table in the left join
        /// </param>
        /// <returns>
        /// HashTable<string>: a HashTable<LeftJoinNode>, containing the keys and values from leftTable and rightTable, left joined together
        /// </returns>
        public static HashTable<LeftJoinNode> LeftJoinHashTables(HashTable<string> leftTable, HashTable<string> rightTable)
        {
            HashTable<LeftJoinNode> leftJoin = new HashTable<LeftJoinNode>();
            for (int i = 0; i < leftTable.HashMap.Length; i++)
            {
                if (leftTable.HashMap[i] != null)
                {
                    var currNode = leftTable.HashMap[i].First;
                    while (currNode != null)
                    {
                        LeftJoinNode newLeftJoinNode = new LeftJoinNode(currNode.Value.Value);
                        if (rightTable.Contains(currNode.Value.Key))
                        {
                            newLeftJoinNode.RightValue = rightTable.Get(currNode.Value.Key);
                        }
                        leftJoin.Add(currNode.Value.Key, newLeftJoinNode);
                        currNode = currNode.Next;
                    }
                }
            }
            return leftJoin;
        }
    }
}
