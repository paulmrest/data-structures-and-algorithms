using System;
using System.Collections.Generic;
using HashTables;
using HashTables.Classes;
using Trees.Classes;

namespace TreeIntersection
{
    public class TreeIntersection<T>
    {
        public static HashSet<T> GetMatchingValuesFor(Tree<T> firstTree, Tree<T> secondTree)
        {
            HashSet<T> traversalSet = new HashSet<T>();
            HashSet<T> returnSet = new HashSet<T>();
            if (firstTree.Root != null && secondTree.Root != null)
            {
                TraverseFirstTree(firstTree.Root, traversalSet);
                TraverseSecondTree(secondTree.Root, traversalSet, returnSet);
            }
            return returnSet;
        }

        private static void TraverseFirstTree(Node<T> currRoot, HashSet<T> traversalSet)
        {
            traversalSet.Add(currRoot.Value);
            if (currRoot.LeftChild != null)
            {
                TraverseFirstTree(currRoot.LeftChild, traversalSet);
            }
            if (currRoot.RightChild != null)
            {
                TraverseFirstTree(currRoot.RightChild, traversalSet);
            }
        }

        private static void TraverseSecondTree(Node<T> currRoot, HashSet<T> traversalSet, HashSet<T> returnSet)
        {
            if (traversalSet.Contains(currRoot.Value))
            {
                returnSet.Add(currRoot.Value);
            }
            if (currRoot.LeftChild != null)
            {
                TraverseSecondTree(currRoot.LeftChild, traversalSet, returnSet);
            }
            if (currRoot.RightChild != null)
            {
                TraverseSecondTree(currRoot.RightChild, traversalSet, returnSet);
            }
        }
    }
}
