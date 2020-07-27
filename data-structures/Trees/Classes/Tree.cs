using System;
using System.Collections.Generic;
using System.Text;
using Trees.Classes;

namespace Trees.Classes
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        /// <summary>
        /// Instantiates an empty tree object.
        /// </summary>
        public Tree()
        {
            Root = null;
        }

        /// <summary>
        /// Instantiates a tree object with a Root Node of type T.
        /// </summary>
        /// <param name="value">
        /// T: a value for the Root Node
        /// </param>
        public Tree(T value)
        {
            Node<T> root = new Node<T>(value);
            Root = root;
        }

        /// <summary>
        /// Returns a pre-ordered List<T> of the Tree's values.
        /// </summary>
        /// <returns>
        /// List<T>: a pre-ordered List<T> of the Tree's values
        /// </returns>
        public List<T> PreOrder()
        {
            List<T> traversal = new List<T>();
            PreOrder(traversal, Root);
            return traversal;
        }

        /// <summary>
        /// Private helper method. Recursively constructs a List<T> of the Tree's values pre-ordered.
        /// </summary>
        /// <param name="traversal">
        /// List<T>: the List<T> the method builds
        /// </param>
        /// <param name="root">
        /// Node<T>: the current root Node<T> of at the present level of recursion
        /// </param>
        private void PreOrder(List<T> traversal, Node<T> root)
        {
            traversal.Add(root.Value);
            if (root.LeftChild != null)
            {
                PreOrder(traversal, root.LeftChild);
            }
            if (root.RightChild != null)
            {
                PreOrder(traversal, root.RightChild);
            }
        }

        /// <summary>
        /// Returns an in-order List<T> of the Tree's values.
        /// </summary>
        /// <returns>
        /// List<T>: an in-ordered List<T> of the Tree's values
        /// </returns>
        public List<T> InOrder()
        {
            List<T> traversal = new List<T>();
            InOrder(traversal, Root);
            return traversal;
        }

        /// <summary>
        /// Private helper method. Recursively constructs a List<T> of the Tree's values in-ordered.
        /// </summary>
        /// <param name="traversal">
        /// List<T>: the List<T> the method builds
        /// </param>
        /// <param name="root">
        /// Node<T>: the current root Node<T> of at the present level of recursion
        /// </param>
        private void InOrder(List<T> traversal, Node<T> root)
        {
            if (root.LeftChild != null)
            {
                InOrder(traversal, root.LeftChild);
            }
            traversal.Add(root.Value);
            if (root.RightChild != null)
            {
                InOrder(traversal, root.RightChild);
            }
        }

        /// <summary>
        /// Returns a post-order List<T> of the Tree's values.
        /// </summary>
        /// <returns>
        /// List<T>: a post-ordered List<T> of the Tree's values
        /// </returns>
        public List<T> PostOrder()
        {
            List<T> traversal = new List<T>();
            PostOrder(traversal, Root);
            return traversal;
        }

        /// <summary>
        /// Private helper method. Recursively constructs a List<T> of the Tree's values post-ordered.
        /// </summary>
        /// <param name="traversal">
        /// List<T>: the List<T> the method builds
        /// </param>
        /// <param name="root">
        /// Node<T>: the current root Node<T> of at the present level of recursion
        /// </param>
        private void PostOrder(List<T> traversal, Node<T> root)
        {
            if (root.LeftChild != null)
            {
                PostOrder(traversal, root.LeftChild);
            }
            if (root.RightChild != null)
            {
                PostOrder(traversal, root.RightChild);
            }
            traversal.Add(root.Value);
        }
    }
}
