using System;

namespace GenericIComparableBST
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public TreeNode<T> LeftChild { get; set; }

        public TreeNode<T> RightChild { get; set; }

        /// <summary>
        /// Instantiates a new TreeNode object with <T> value. <T> must implement IComparable.
        /// </summary>
        /// <param name="value">
        /// T: a value for the node, which much implement IComparable
        /// </param>
        public TreeNode(T value)
        {
            Value = value;
        }
    }
}
