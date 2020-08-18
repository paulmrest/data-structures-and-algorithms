using System;
using System.Collections.Generic;
using System.Text;
using GenericIComparableBST.Classes;

namespace GenericIComparableBST.Classes
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; set; }

        /// <summary>
        /// Instantiates an empty binary search tree.
        /// </summary>
        public BinarySearchTree()
        {
            Root = null;
        }

        /// <summary>
        /// Instantiates a binary search tree with a Root Node of type T.
        /// </summary>
        /// <param name="value">
        /// T (must implement IComparable): a value for the Root Node
        /// </param>
        public BinarySearchTree(T value)
        {
            TreeNode<T> root = new TreeNode<T>(value);
            Root = root;
        }

        /// <summary>
        /// Adds a new node to the tree, keeping it sorted.
        /// </summary>
        /// <param name="value">
        /// T (must implement IComparable): the value to be added to the tree
        /// </param>
        public void Add(T value)
        {
            TreeNode<T> newNode = new TreeNode<T>(value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                TreeNode<T> currNode = Root;
                while (currNode != null)
                {
                    if (currNode.Value.CompareTo(value) > 0)
                    {
                        if (currNode.LeftChild == null)
                        {
                            currNode.LeftChild = newNode;
                            break;
                        }
                        else
                        {
                            currNode = currNode.LeftChild;
                        }
                    }
                    else
                    {
                        if (currNode.RightChild == null)
                        {
                            currNode.RightChild = newNode;
                            break;
                        }
                        else
                        {
                            currNode = currNode.RightChild;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if tree contains value, returns true if the tree does, false otherwise.
        /// </summary>
        /// <param name="value">
        /// T (must implement IComparable): the value to search for
        /// </param>
        /// <returns>
        /// bool: a bool indicating whether the tree contains the value
        /// </returns>
        public bool Contains(T value)
        {
            if (Root != null)
            {
                TreeNode<T> currNode = Root;
                while (currNode != null)
                {
                    if (currNode.Value.CompareTo(value) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        //if (currNode.Value > value)
                        if (currNode.Value.CompareTo(value) > 0)
                        {
                            currNode = currNode.LeftChild;
                        }
                        else
                        {
                            currNode = currNode.RightChild;
                        }
                    }
                }
            }
            return false;
        }
    }
}
