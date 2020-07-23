using System;
using Xunit;
using MultiBracketValidationTesting;

namespace MultiBracketValidationTesting
{
    public class MultiBracketValidationTests
    {
        [Fact]
        public void ReturnsTrueForAnEmptyString()
        {
            //Arrange
            string input = "";

            //Assert
            Assert.True(MultiBracketValidation.Program.MultiBracketValidation(input));
        }

        [Fact]
        public void ReturnsTrueForAStringWithNoBrackets()
        {
            //Arrange
            string input = "This string contains exactly zero brackets";

            //Assert
            Assert.True(MultiBracketValidation.Program.MultiBracketValidation(input));
        }

        [Fact]
        public void ReturnsTrueForAStringWithBalancedBrackets()
        {
            //Arrange
            string input = "([{}])";

            //Assert
            Assert.True(MultiBracketValidation.Program.MultiBracketValidation(input));
        }
    }
}
