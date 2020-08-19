using System;
using System.Collections.Generic;
using HashTables;
using HashTables.Classes;
using Trees.Classes;

namespace TreeIntersection
{
    public class TreeIntersection<T>
    {
        /// <summary>
        /// Given two Tree<T> objects, returns a HashSet<T> of all the values in both trees.
        /// </summary>
        /// <param name="firstTree">
        /// Tree<T>: one of the two Tree<T> objects
        /// </param>
        /// <param name="secondTree">
        /// Tree<T>: the second Tree<T>
        /// </param>
        /// <returns>
        /// HashSet<T>: a HashSet<T> of the values in both trees
        /// </returns>
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

        /// <summary>
        /// Private helper method. Recursively traverses the first tree and assembles a traversal HashSet<T> of all the elements in the tree.
        /// </summary>
        /// <param name="currRoot">
        /// Node<T>: the root level Node for the current block in the recursion
        /// </param>
        /// <param name="traversalSet">
        /// HashSet<T>: the HashSet<T> assembled in place as the tree is traversed
        /// </param>
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

        /// <summary>
        /// Prviate helper method. Recursively traverses the second tree and assembles a HashSet<T> of values in both trees.
        /// </summary>
        /// <param name="currRoot">
        /// Node<T>: the root level Node for the current block in the recursion
        /// </param>
        /// <param name="traversalSet">
        /// HashSet<T>: the HashSet<T> from the first tree
        /// </param>
        /// <param name="returnSet">
        /// HashSet<T>: the HashSet<T> of values present in both the first and second tree
        /// </param>
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
