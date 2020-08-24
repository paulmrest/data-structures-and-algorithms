using System;
using Xunit;
using HashTables;
using LeftJoin.Classes;

namespace LeftJoinTesting
{
    public class LeftJoinTests
    {
        [Fact]
        public void ReturnsAnEmptyTableWhenGivenEmptyTables()
        {
            //Arrange
            HashTable<string> testTableOne = new HashTable<string>();

            HashTable<string> testTableTwo = new HashTable<string>();

            //Act
            HashTable<LeftJoinNode> resultTable = LeftJoin.LeftJoin.LeftJoinHashTables(testTableOne, testTableTwo);

            //Assert
            Assert.NotNull(resultTable);
            Assert.Equal(0, resultTable.Count);
        }

        [Fact]
        public void CanLeftJoinTwoHashTables()
        {
            //Arrange
            HashTable<string> testTableOne = new HashTable<string>(20);
            testTableOne.Add("fond", "enamored");
            testTableOne.Add("wrath", "anger");
            testTableOne.Add("diligent", "employed");
            testTableOne.Add("outfit", "garb");
            testTableOne.Add("guide", "usher");

            HashTable<string> testTableTwo = new HashTable<string>(20);
            testTableTwo.Add("fond", "averse");
            testTableTwo.Add("wrath", "delight");
            testTableTwo.Add("diligent", "idle");
            testTableTwo.Add("guide", "follow");
            testTableTwo.Add("flow", "jam");

            string[][] expectedArray = new string[][]
            {
                new string[]{"fond", "enamored", "averse" },
                new string[]{"wrath", "anger", "delight" },
                new string[]{"diligent", "employed", "idle" },
                new string[]{"outfit", "garb", "" },
                new string[]{"guide", "usher", "follow" }
            };

            //Act
            HashTable<LeftJoinNode> resultTable = LeftJoin.LeftJoin.LeftJoinHashTables(testTableOne, testTableTwo);

            //Assert
            Assert.NotNull(resultTable);
            bool expectedResultsMatch = true;
            foreach (string[] stringArray in expectedArray)
            {
                LeftJoinNode leftJoinNode = resultTable.Get(stringArray[0]);
                if (leftJoinNode.LeftValue != stringArray[1] || leftJoinNode.RightValue != stringArray[2])
                {
                    expectedResultsMatch = false;
                    break;
                }
            }
            Assert.True(expectedResultsMatch);
        }

        [Fact]
        public void CanLeftJoinTwoTablesWithNoMatchingKeysInRightTable()
        {
            //Arrange
            HashTable<string> testTableOne = new HashTable<string>(20);
            testTableOne.Add("fond", "enamored");
            testTableOne.Add("wrath", "anger");
            testTableOne.Add("diligent", "employed");
            testTableOne.Add("outfit", "garb");
            testTableOne.Add("guide", "usher");

            HashTable<string> testTableTwo = new HashTable<string>(20);
            testTableTwo.Add("frond", "averse");
            testTableTwo.Add("wraith", "delight");
            testTableTwo.Add("Dillinger", "idle");
            testTableTwo.Add("guess", "follow");
            testTableTwo.Add("float", "jam");

            string[][] expectedArray = new string[][]
            {
                new string[]{"fond", "enamored", "" },
                new string[]{"wrath", "anger", "" },
                new string[]{"diligent", "employed", "" },
                new string[]{"outfit", "garb", "" },
                new string[]{"guide", "usher", "" }
            };

            //Act
            HashTable<LeftJoinNode> resultTable = LeftJoin.LeftJoin.LeftJoinHashTables(testTableOne, testTableTwo);

            //Assert
            Assert.NotNull(resultTable);
            bool expectedResultsMatch = true;
            foreach (string[] stringArray in expectedArray)
            {
                LeftJoinNode leftJoinNode = resultTable.Get(stringArray[0]);
                if (leftJoinNode.LeftValue != stringArray[1] || leftJoinNode.RightValue != stringArray[2])
                {
                    expectedResultsMatch = false;
                    break;
                }
            }
            Assert.True(expectedResultsMatch);
        }

        [Fact]
        public void ReturnsAnEmptyHashTableWhenLeftTableIsEmpty()
        {
            //Arrange
            HashTable<string> testTableOne = new HashTable<string>(20);

            HashTable<string> testTableTwo = new HashTable<string>(20);
            testTableTwo.Add("frond", "averse");
            testTableTwo.Add("wraith", "delight");
            testTableTwo.Add("Dillinger", "idle");
            testTableTwo.Add("guess", "follow");
            testTableTwo.Add("float", "jam");

            //Act
            HashTable<LeftJoinNode> resultTable = LeftJoin.LeftJoin.LeftJoinHashTables(testTableOne, testTableTwo);

            //Assert
            Assert.NotNull(resultTable);
            Assert.Equal(0, resultTable.Count);
        }
    }
}
