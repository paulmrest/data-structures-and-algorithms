using System;
using Xunit;
using HashTables.Classes;
using HashTables;
using LeftJoin;

namespace LeftJoinTesting
{
    public class LeftJoinTests
    {
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

            string[,] expected = new string[,]
            {
                {"fond", "enamored", "averse" },
                {"wrath", "anger", "delight" },
                {"diligent", "employed", "idle" },
                {"outfit", "garb", "" },
                {"guide", "usher", "follow" }
            };

            //Act
            string[,] result = LeftJoin.LeftJoin.LeftJoinHashTables(testTableOne, testTableTwo);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.GetLength(0));
            Assert.Equal(3, result.GetLength(1));
            bool equalMatrices = true;
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                string key = expected[i, 0];
                bool matchingRowFound = false;
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (expected[i, 0] == result[j, 0])
                    {
                        matchingRowFound = expected[i, 1] == result[j, 1] && expected[i, 2] == result[j, 2];
                    }
                }
                if (!matchingRowFound)
                {
                    equalMatrices = false;
                    break;
                }
            }
            Assert.True(equalMatrices);
        }
    }
}
