using System;
using Trees.Classes;

namespace FindMaximumValue
{
    public static class FindMaximumValueExtension
    {
        /// <summary>
        /// Extension method that finds and returns the maximum value in a Tree<int>.
        /// </summary>
        /// <param name="tree">
        /// Tree<int>: a Tree of integers
        /// </param>
        /// <returns>
        /// int: the maximum value in the tree
        /// </returns>
        /// <throws>
        /// InvalidOperationException: if tree is empty
        /// </throws>
        public static int FindMaximumValue(this Tree<int> tree)
        {
            if (tree.Root == null)
            {
                throw new InvalidOperationException("Tree contains no nodes.");
            }
            return FindMaximumValue(tree.Root, tree.Root.Value);
        }

        /// <summary>
        /// Private helper method that recursively traverses the tree and finds the maximum value.
        /// </summary>
        /// <param name="currNode">
        /// Node<int>: the current Node being looked at in the recursion
        /// </param>
        /// <param name="currMax">
        /// int: the maximum value found up to this Node
        /// </param>
        /// <returns>
        /// int: the maximum value found after traversing the child nodes
        /// </returns>
        private static int FindMaximumValue(Node<int> currNode, int currMax)
        {
            if (currNode.Value > currMax)
            {
                currMax = currNode.Value;
            }
            if (currNode.LeftChild != null)
            {
                currMax = FindMaximumValue(currNode.LeftChild, currMax);
            }
            if (currNode.RightChild != null)
            {
                currMax = FindMaximumValue(currNode.RightChild, currMax);
            }
            return currMax;
        }
    }
}
