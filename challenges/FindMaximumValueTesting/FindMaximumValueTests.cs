using System;
using Xunit;
using Trees.Classes;
using FindMaximumValue;

namespace FindMaximumValueTesting
{
    public class FindMaximumValueTests
    {
        [Fact]
        public void CanFindMaximumValueInATreeWithOneNode()
        {
            //Arrange
            Tree<int> testTree = new Tree<int>(52);

            //Assert
            Assert.Equal(52, FindMaximumValueExtension.FindMaximumValue(testTree));
        }

        [Fact]
        public void ThrowsExceptionForEmptyTree()
        {
            //Arrange
            Tree<int> testTree = new Tree<int>();

            //Assert
            Assert.Throws<InvalidOperationException>(() => FindMaximumValueExtension.FindMaximumValue(testTree));
        }

        [Fact]
        public void CanFindMaximumValueInAnUnbalancedTree()
        {
            //Arrange
            Tree<int> testTree = new Tree<int>(52);

            Node<int> node1 = new Node<int>(23);
            Node<int> node2 = new Node<int>(12);
            Node<int> node3 = new Node<int>(105);
            Node<int> node4 = new Node<int>(9);
            Node<int> node5 = new Node<int>(99);
            Node<int> node6 = new Node<int>(39);
            Node<int> node7 = new Node<int>(238);

            testTree.Root.LeftChild = node1;

            testTree.Root.RightChild = node2;
            testTree.Root.RightChild.LeftChild = node3;
            testTree.Root.RightChild.LeftChild.RightChild = node4;
            testTree.Root.RightChild.LeftChild.RightChild.RightChild = node5;
            testTree.Root.RightChild.LeftChild.RightChild.RightChild.RightChild = node6;
            testTree.Root.RightChild.RightChild = node7;

            //Assert
            Assert.Equal(238, FindMaximumValueExtension.FindMaximumValue(testTree));
        }

        [Fact]
        public void CanFindMaximumValueInABalancedTree()
        {
            //Arrange
            Tree<int> testTree = new Tree<int>(52);

            Node<int> node1 = new Node<int>(23);
            Node<int> node2 = new Node<int>(12);
            Node<int> node3 = new Node<int>(105);
            Node<int> node4 = new Node<int>(9);
            Node<int> node5 = new Node<int>(99);
            Node<int> node6 = new Node<int>(39);
            Node<int> node7 = new Node<int>(238);

            testTree.Root.LeftChild = node1;
            testTree.Root.LeftChild.LeftChild = node2;
            testTree.Root.LeftChild.RightChild = node3;

            testTree.Root.RightChild = node4;
            testTree.Root.RightChild.LeftChild = node5;
            testTree.Root.RightChild.LeftChild.RightChild = node6;
            testTree.Root.RightChild.RightChild = node7;

            //Assert
            Assert.Equal(238, FindMaximumValueExtension.FindMaximumValue(testTree));
        }
    }
}
