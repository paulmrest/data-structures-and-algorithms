using System;
using Xunit;
using TreeIntersection;
using Trees.Classes;
using System.Collections.Generic;

namespace TreeIntersectionTesting
{
    public class TreeIntersectionTests
    {

        [Fact]
        public void FindsNoIntersectingValuesWhenBothTreesAreNull()
        {
            //Arrange
            Tree<string> testTreeOne = new Tree<string>();

            Tree<string> testTreeTwo = new Tree<string>();

            string[] expected = new string[0];

            //Act
            HashSet<string> result = TreeIntersection<string>.GetMatchingValuesFor(testTreeOne, testTreeTwo);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Length, result.Count);
            bool matching = true;
            foreach (string oneString in expected)
            {
                if (!result.Contains(oneString))
                {
                    matching = false;
                    break;
                }
            }
            Assert.True(matching);
        }


        [Fact]
        public void FindsNoIntersectingValuesWhenOneTreeIsNull()
        {
            //Arrange
            string rootStringOne = "A";
            Tree<string> testTreeOne = new Tree<string>(rootStringOne);

            string rootLeftChildStringOne = "B";
            Node<string> rootLeftChildOne = new Node<string>(rootLeftChildStringOne);
            string BLeftChildStringOne = "C";
            rootLeftChildOne.LeftChild = new Node<string>(BLeftChildStringOne);
            string BRightChildStringOne = "D";
            rootLeftChildOne.RightChild = new Node<string>(BRightChildStringOne);

            testTreeOne.Root.LeftChild = rootLeftChildOne;

            string rootRightChildStringOne = "E";
            Node<string> rootRightChildOne = new Node<string>(rootRightChildStringOne);
            string ELeftChildStringOne = "F";
            rootRightChildOne.LeftChild = new Node<string>(ELeftChildStringOne);
            string ERightChildStringOne = "G";
            rootRightChildOne.RightChild = new Node<string>(ERightChildStringOne);

            testTreeOne.Root.RightChild = rootRightChildOne;


            Tree<string> testTreeTwo = new Tree<string>();


            string[] expected = new string[0];


            //Act
            HashSet<string> result = TreeIntersection<string>.GetMatchingValuesFor(testTreeOne, testTreeTwo);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Length, result.Count);
            bool matching = true;
            foreach (string oneString in expected)
            {
                if (!result.Contains(oneString))
                {
                    matching = false;
                    break;
                }
            }
            Assert.True(matching);
        }

        [Fact]
        public void ForTwoTwoTreesWithIdenticalValuesInEveryNodeReturnsOneValue()
        {
            //Arrange
            string rootStringOne = "G";
            Tree<string> testTreeOne = new Tree<string>(rootStringOne);

            string rootLeftChildStringOne = "G";
            Node<string> rootLeftChildOne = new Node<string>(rootLeftChildStringOne);
            string BLeftChildStringOne = "G";
            rootLeftChildOne.LeftChild = new Node<string>(BLeftChildStringOne);
            string BRightChildStringOne = "G";
            rootLeftChildOne.RightChild = new Node<string>(BRightChildStringOne);

            testTreeOne.Root.LeftChild = rootLeftChildOne;

            string rootRightChildStringOne = "G";
            Node<string> rootRightChildOne = new Node<string>(rootRightChildStringOne);
            string ELeftChildStringOne = "G";
            rootRightChildOne.LeftChild = new Node<string>(ELeftChildStringOne);
            string ERightChildStringOne = "G";
            rootRightChildOne.RightChild = new Node<string>(ERightChildStringOne);

            testTreeOne.Root.RightChild = rootRightChildOne;


            string rootStringTwo = "G";
            Tree<string> testTreeTwo = new Tree<string>(rootStringTwo);

            string rootLeftChildStringTwo = "G";
            Node<string> rootLeftChildTwo = new Node<string>(rootLeftChildStringTwo);
            string BLeftChildStringTwo = "G";
            rootLeftChildTwo.LeftChild = new Node<string>(BLeftChildStringTwo);
            string BRightChildStringTwo = "G";
            rootLeftChildTwo.RightChild = new Node<string>(BRightChildStringTwo);

            testTreeTwo.Root.LeftChild = rootLeftChildTwo;

            string rootRightChildStringTwo = "G";
            Node<string> rootRightChildTwo = new Node<string>(rootRightChildStringTwo);
            string ELeftChildStringTwo = "G";
            rootRightChildTwo.LeftChild = new Node<string>(ELeftChildStringTwo);
            string ERightChildStringTwo = "G";
            rootRightChildTwo.RightChild = new Node<string>(ERightChildStringTwo);

            testTreeTwo.Root.RightChild = rootRightChildTwo;

            string[] expected = new string[] { "G" };

            //Act
            HashSet<string> result = TreeIntersection<string>.GetMatchingValuesFor(testTreeOne, testTreeTwo);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Length, result.Count);
            bool matching = true;
            foreach (string oneString in expected)
            {
                if (!result.Contains(oneString))
                {
                    matching = false;
                    break;
                }
            }
            Assert.True(matching);
        }

        [Fact]
        public void ForTwoTreesWithNoIntersectingValuesFindsNone()
        {
            //Arrange
            string rootStringOne = "A";
            Tree<string> testTreeOne = new Tree<string>(rootStringOne);

            string rootLeftChildStringOne = "B";
            Node<string> rootLeftChildOne = new Node<string>(rootLeftChildStringOne);
            string BLeftChildStringOne = "C";
            rootLeftChildOne.LeftChild = new Node<string>(BLeftChildStringOne);
            string BRightChildStringOne = "D";
            rootLeftChildOne.RightChild = new Node<string>(BRightChildStringOne);

            testTreeOne.Root.LeftChild = rootLeftChildOne;

            string rootRightChildStringOne = "E";
            Node<string> rootRightChildOne = new Node<string>(rootRightChildStringOne);
            string ELeftChildStringOne = "F";
            rootRightChildOne.LeftChild = new Node<string>(ELeftChildStringOne);
            string ERightChildStringOne = "G";
            rootRightChildOne.RightChild = new Node<string>(ERightChildStringOne);

            testTreeOne.Root.RightChild = rootRightChildOne;


            string rootStringTwo = "X";
            Tree<string> testTreeTwo = new Tree<string>(rootStringTwo);

            string rootLeftChildStringTwo = "Z";
            Node<string> rootLeftChildTwo = new Node<string>(rootLeftChildStringTwo);
            string BLeftChildStringTwo = "P";
            rootLeftChildTwo.LeftChild = new Node<string>(BLeftChildStringTwo);
            string BRightChildStringTwo = "T";
            rootLeftChildTwo.RightChild = new Node<string>(BRightChildStringTwo);

            testTreeTwo.Root.LeftChild = rootLeftChildTwo;

            string rootRightChildStringTwo = "K";
            Node<string> rootRightChildTwo = new Node<string>(rootRightChildStringTwo);
            string ELeftChildStringTwo = "Q";
            rootRightChildTwo.LeftChild = new Node<string>(ELeftChildStringTwo);
            string ERightChildStringTwo = "V";
            rootRightChildTwo.RightChild = new Node<string>(ERightChildStringTwo);

            testTreeTwo.Root.RightChild = rootRightChildTwo;

            string[] expected = new string[0];


            //Act
            HashSet<string> result = TreeIntersection<string>.GetMatchingValuesFor(testTreeOne, testTreeTwo);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Length, result.Count);
            bool matching = true;
            foreach (string oneString in expected)
            {
                if (!result.Contains(oneString))
                {
                    matching = false;
                    break;
                }
            }
            Assert.True(matching);
        }

        [Fact]
        public void CanFindIntersectingValuesInTwoTrees()
        {
            //Arrange
            string rootStringOne = "A";
            Tree<string> testTreeOne = new Tree<string>(rootStringOne);

            string rootLeftChildStringOne = "B";
            Node<string> rootLeftChildOne = new Node<string>(rootLeftChildStringOne);
            string BLeftChildStringOne = "C";
            rootLeftChildOne.LeftChild = new Node<string>(BLeftChildStringOne);
            string BRightChildStringOne = "D";
            rootLeftChildOne.RightChild = new Node<string>(BRightChildStringOne);

            testTreeOne.Root.LeftChild = rootLeftChildOne;

            string rootRightChildStringOne = "E";
            Node<string> rootRightChildOne = new Node<string>(rootRightChildStringOne);
            string ELeftChildStringOne = "F";
            rootRightChildOne.LeftChild = new Node<string>(ELeftChildStringOne);
            string ERightChildStringOne = "G";
            rootRightChildOne.RightChild = new Node<string>(ERightChildStringOne);

            testTreeOne.Root.RightChild = rootRightChildOne;


            string rootStringTwo = "C";
            Tree<string> testTreeTwo = new Tree<string>(rootStringTwo);

            string rootLeftChildStringTwo = "Z";
            Node<string> rootLeftChildTwo = new Node<string>(rootLeftChildStringTwo);
            string BLeftChildStringTwo = "P";
            rootLeftChildTwo.LeftChild = new Node<string>(BLeftChildStringTwo);
            string BRightChildStringTwo = "G";
            rootLeftChildTwo.RightChild = new Node<string>(BRightChildStringTwo);

            testTreeTwo.Root.LeftChild = rootLeftChildTwo;

            string rootRightChildStringTwo = "K";
            Node<string> rootRightChildTwo = new Node<string>(rootRightChildStringTwo);
            string ELeftChildStringTwo = "Q";
            rootRightChildTwo.LeftChild = new Node<string>(ELeftChildStringTwo);
            string ERightChildStringTwo = "B";
            rootRightChildTwo.RightChild = new Node<string>(ERightChildStringTwo);

            testTreeTwo.Root.RightChild = rootRightChildTwo;

            string[] expected = new string[] { "C", "G", "B" };


            //Act
            HashSet<string> result = TreeIntersection<string>.GetMatchingValuesFor(testTreeOne, testTreeTwo);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Length, result.Count);
            bool matching = true;
            foreach (string oneString in expected)
            {
                if (!result.Contains(oneString))
                {
                    matching = false;
                    break;
                }
            }
            Assert.True(matching);
        }
    }
}
