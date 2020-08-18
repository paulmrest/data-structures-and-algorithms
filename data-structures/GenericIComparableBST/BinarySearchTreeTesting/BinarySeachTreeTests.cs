using System;
using Xunit;
using GenericIComparableBST.Classes;

namespace BinarySearchTreeTests
{
    public class BinarySeachTreeTests
    {
        [Fact]
        public void CanInstantiateAnEmptyBST()
        {
            //Arrange
            BinarySearchTree<int> testBST = new BinarySearchTree<int>();

            //Assert
            Assert.Null(testBST.Root);
        }

        [Fact]
        public void CanInstantiateBSTWithARootNode()
        {
            //Arrange
            int rootInt = 500;
            BinarySearchTree<int> testBST = new BinarySearchTree<int>(rootInt);

            //Assert
            Assert.Equal(rootInt, testBST.Root.Value);
        }

        [Fact]
        public void CanAddRootToEmptyBST()
        {
            //Arrange
            BinarySearchTree<int> testBST = new BinarySearchTree<int>();

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
            BinarySearchTree<int> testBST = new BinarySearchTree<int>(rootValue);

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
            BinarySearchTree<int> testBST = new BinarySearchTree<int>(rootValue);

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
            BinarySearchTree<int> testBST = new BinarySearchTree<int>(rootValue);

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

        [Fact]
        public void CanBuildSortedTreeOfStrings()
        {
            //Arrange
            string rootValue = "NOVEMBER"; //500
            BinarySearchTree<string> testBST = new BinarySearchTree<string>(rootValue);

            //Act
            string rootLeftChildValue = "HOTEL"; //250
            testBST.Add(rootLeftChildValue);

            string rootRightChildValue = "ROMEO"; //750
            testBST.Add(rootRightChildValue);

            string rootLeftLeft = "CHARLIE"; //150
            testBST.Add(rootLeftLeft);

            string rootLeftRight = "KILO"; //300
            testBST.Add(rootLeftRight);

            string rootRightLeft = "PAPA"; //600
            testBST.Add(rootRightLeft);

            string rootRightRight = "TANGO"; //900
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
            BinarySearchTree<int> testBST = new BinarySearchTree<int>(rootValue);

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
            BinarySearchTree<int> testBST = new BinarySearchTree<int>(rootValue);

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