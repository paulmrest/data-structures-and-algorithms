using System;
using Xunit;
using Trees.Classes;
using System.Collections.Generic;
using System.Linq;

namespace TreeTesting
{
    public class TreeTests
    {
        [Fact]
        public void CanInstansiateAnEmptyTree()
        {
            //Arrange
            Tree<string> testTree = new Tree<string>();

            //Assert
            Assert.Null(testTree.Root);
        }

        [Fact]
        public void CanInstansiateATreeWithARootNode()
        {
            //Arrange
            string rootString = "the stringiest string";
            Tree<string> testTree = new Tree<string>(rootString);

            //Assert
            Assert.Equal(rootString, testTree.Root.Value);
        }

        [Fact]
        public void CanAddALeftChildNode()
        {
            //Arrange
            string rootString = "the stringiest string";
            Tree<string> testTree = new Tree<string>(rootString);
            string leftChild = "lefty";
            testTree.Root.LeftChild = new Node<string>(leftChild);

            //Assert
            Assert.Equal(leftChild, testTree.Root.LeftChild.Value);
        }

        [Fact]
        public void CanAddARightChildNode()
        {
            //Arrange
            string rootString = "the stringiest string";
            Tree<string> testTree = new Tree<string>(rootString);
            string rightChild = "righty";
            testTree.Root.RightChild = new Node<string>(rightChild);

            //Assert
            Assert.Equal(rightChild, testTree.Root.RightChild.Value);
        }

        [Fact]
        public void CanReturnAPreOrderedTravesal()
        {
            //Arrange
            string rootString = "A";
            Tree<string> testTree = new Tree<string>(rootString);

            string rootLeftChildString = "B";
            Node<string> rootLeftChild = new Node<string>(rootLeftChildString);
            string BLeftChildString = "C";
            rootLeftChild.LeftChild = new Node<string>(BLeftChildString);
            string BRightChildString = "D";
            rootLeftChild.RightChild = new Node<string>(BRightChildString);

            testTree.Root.LeftChild = rootLeftChild;

            string rootRightChildString = "E";
            Node<string> rootRightChild = new Node<string>(rootRightChildString);
            string ELeftChildString = "F";
            rootRightChild.LeftChild = new Node<string>(ELeftChildString);
            string ERightChildString = "G";
            rootRightChild.RightChild = new Node<string>(ERightChildString);

            testTree.Root.RightChild = rootRightChild;

            List<string> expected = new List<string>();
            expected.Add(rootString);
            expected.Add(rootLeftChildString);
            expected.Add(BLeftChildString);
            expected.Add(BRightChildString);
            expected.Add(rootRightChildString);
            expected.Add(ELeftChildString);
            expected.Add(ERightChildString);

            //Act
            List<string> output = testTree.PreOrder();

            //Assert
            Assert.True(Enumerable.SequenceEqual(expected, output));
        }

        [Fact]
        public void CanReturnAnInOrderTravesal()
        {
            //Arrange
            string rootString = "A";
            Tree<string> testTree = new Tree<string>(rootString);

            string rootLeftChildString = "B";
            Node<string> rootLeftChild = new Node<string>(rootLeftChildString);
            string BLeftChildString = "C";
            rootLeftChild.LeftChild = new Node<string>(BLeftChildString);
            string BRightChildString = "D";
            rootLeftChild.RightChild = new Node<string>(BRightChildString);

            testTree.Root.LeftChild = rootLeftChild;

            string rootRightChildString = "E";
            Node<string> rootRightChild = new Node<string>(rootRightChildString);
            string ELeftChildString = "F";
            rootRightChild.LeftChild = new Node<string>(ELeftChildString);
            string ERightChildString = "G";
            rootRightChild.RightChild = new Node<string>(ERightChildString);

            testTree.Root.RightChild = rootRightChild;

            List<string> expected = new List<string>();
            expected.Add(BLeftChildString);
            expected.Add(rootLeftChildString);
            expected.Add(BRightChildString);
            expected.Add(rootString);
            expected.Add(ELeftChildString);
            expected.Add(rootRightChildString);
            expected.Add(ERightChildString);

            //Act
            List<string> output = testTree.InOrder();

            //Assert
            Assert.True(Enumerable.SequenceEqual(expected, output));
        }

        [Fact]
        public void CanReturnAPostOrderTravesal()
        {
            //Arrange
            string rootString = "A";
            Tree<string> testTree = new Tree<string>(rootString);

            string rootLeftChildString = "B";
            Node<string> rootLeftChild = new Node<string>(rootLeftChildString);
            string BLeftChildString = "C";
            rootLeftChild.LeftChild = new Node<string>(BLeftChildString);
            string BRightChildString = "D";
            rootLeftChild.RightChild = new Node<string>(BRightChildString);

            testTree.Root.LeftChild = rootLeftChild;

            string rootRightChildString = "E";
            Node<string> rootRightChild = new Node<string>(rootRightChildString);
            string ELeftChildString = "F";
            rootRightChild.LeftChild = new Node<string>(ELeftChildString);
            string ERightChildString = "G";
            rootRightChild.RightChild = new Node<string>(ERightChildString);

            testTree.Root.RightChild = rootRightChild;

            List<string> expected = new List<string>();
            expected.Add(BLeftChildString);
            expected.Add(BRightChildString);
            expected.Add(rootLeftChildString);
            expected.Add(ELeftChildString);
            expected.Add(ERightChildString);
            expected.Add(rootRightChildString);
            expected.Add(rootString);

            //Act
            List<string> output = testTree.PostOrder();

            //Assert
            Assert.True(Enumerable.SequenceEqual(expected, output));
        }
    }

    public class BinarySearchTreeTests
    {
        [Fact]
        public void CanInstantiateAnEmptyBST()
        {
            //Arrange
            BinarySearchTree testBST = new BinarySearchTree();

            //Assert
            Assert.Null(testBST.Root);
        }

        [Fact]
        public void CanInstantiateBSTWithARootNode()
        {
            //Arrange
            int rootInt = 500;
            BinarySearchTree testBST = new BinarySearchTree(rootInt);

            //Assert
            Assert.Equal(rootInt, testBST.Root.Value);
        }

        [Fact]
        public void CanAddRootToEmptyBST()
        {
            //Arrange
            BinarySearchTree testBST = new BinarySearchTree();

            //Act
            int rootValue = 500;
            testBST.Add(rootValue);

            //Assert
            Assert.Equal(rootValue, testBST.Root.Value);
        }

        [Fact]
        public void CanAddLeftChild()
        {
            //Arrange
            int rootValue = 500;
            BinarySearchTree testBST = new BinarySearchTree(rootValue);

            //Act
            int rootLeftChildValue = 250;
            testBST.Add(rootLeftChildValue);

            //Assert
            Assert.Equal(rootLeftChildValue, testBST.Root.LeftChild.Value);
        }

        [Fact]
        public void CanAddRightChild()
        {
            //Arrange
            int rootValue = 500;
            BinarySearchTree testBST = new BinarySearchTree(rootValue);

            //Act
            int rootRightChildValue = 750;
            testBST.Add(rootRightChildValue);

            //Assert
            Assert.Equal(rootRightChildValue, testBST.Root.RightChild.Value);
        }

        [Fact]
        public void CanBuildSortedTree()
        {
            //Arrange
            int rootValue = 500;
            BinarySearchTree testBST = new BinarySearchTree(rootValue);

            //Act
            int rootLeftChildValue = 250;
            testBST.Add(rootLeftChildValue);

            int rootRightChildValue = 750;
            testBST.Add(rootRightChildValue);

            int rootLeftLeft = 150;
            testBST.Add(rootLeftLeft);

            int rootLeftRight = 300;
            testBST.Add(rootLeftRight);

            int rootRightLeft = 600;
            testBST.Add(rootRightLeft);

            int rootRightRight = 900;
            testBST.Add(rootRightRight);

            //Assert
            Assert.Equal(rootLeftLeft, testBST.Root.LeftChild.LeftChild.Value);
            Assert.Equal(rootLeftRight, testBST.Root.LeftChild.RightChild.Value);
            Assert.Equal(rootRightLeft, testBST.Root.RightChild.LeftChild.Value);
            Assert.Equal(rootRightRight, testBST.Root.RightChild.RightChild.Value);
        }

        [Theory]
        [InlineData(600)]
        [InlineData(250)]
        [InlineData(150)]
        public void ContainsReturnsTrueSearchingForPresentValues(int input)
        {
            //Arrange
            int rootValue = 500;
            BinarySearchTree testBST = new BinarySearchTree(rootValue);

            //Act
            int rootLeftChildValue = 250;
            testBST.Add(rootLeftChildValue);

            int rootRightChildValue = 750;
            testBST.Add(rootRightChildValue);

            int rootLeftLeft = 150;
            testBST.Add(rootLeftLeft);

            int rootLeftRight = 300;
            testBST.Add(rootLeftRight);

            int rootRightLeft = 600;
            testBST.Add(rootRightLeft);

            int rootRightRight = 900;
            testBST.Add(rootRightRight);

            //Assert
            Assert.True(testBST.Contains(input));
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(-55)]
        [InlineData(0)]
        public void ContainsReturnsFalseSearchingForNotPresentValues(int input)
        {
            //Arrange
            int rootValue = 500;
            BinarySearchTree testBST = new BinarySearchTree(rootValue);

            //Act
            int rootLeftChildValue = 250;
            testBST.Add(rootLeftChildValue);

            int rootRightChildValue = 750;
            testBST.Add(rootRightChildValue);

            int rootLeftLeft = 150;
            testBST.Add(rootLeftLeft);

            int rootLeftRight = 300;
            testBST.Add(rootLeftRight);

            int rootRightLeft = 600;
            testBST.Add(rootRightLeft);

            int rootRightRight = 900;
            testBST.Add(rootRightRight);

            //Assert
            Assert.True(!testBST.Contains(input));
        }
    }
}
