﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Classes
{
    public class BinarySearchTree
    {
        public Node<int> Root { get; set; }

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
        /// T: a value for the Root Node
        /// </param>
        public BinarySearchTree(int value)
        {
            Node<int> root = new Node<int>(value);
            Root = root;
        }

        /// <summary>
        /// Adds a new node to the tree, keeping it sorted.
        /// </summary>
        /// <param name="value">
        /// int: the value to be added to the tree
        /// </param>
        public void Add(int value)
        {
            Node<int> newNode = new Node<int>(value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                Node<int> currNode = Root;
                while (currNode != null)
                {
                    if (currNode.Value >= value)
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
                    if (currNode.Value < value)
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
        /// int: the value to search for
        /// </param>
        /// <returns>
        /// bool: a bool indicating whether the tree contains the value
        /// </returns>
        public bool Contains(int value)
        {
            if (Root != null)
            {
                Node<int> currNode = Root;
                while (currNode != null)
                {
                    if (currNode.Value == value)
                    {
                        return true;
                    }
                    else
                    {
                        if (currNode.Value > value)
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
