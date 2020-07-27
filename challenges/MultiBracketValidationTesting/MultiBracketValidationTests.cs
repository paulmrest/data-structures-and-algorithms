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

        [Fact]
        public void ReturnsFalseForAStringWithUnbalancedBrackets()
        {
            //Arrange
            string input = "([{})";

            //Assert
            Assert.True(!MultiBracketValidation.Program.MultiBracketValidation(input));
        }

        [Fact]
        public void ReturnsFalseForAStringWithOnlyClosingBrackets()
        {
            //Arrange
            string input = "})";

            //Assert
            Assert.True(!MultiBracketValidation.Program.MultiBracketValidation(input));
        }

        [Fact]
        public void ReturnsFalseForAStringWithOnlyOpeningBrackets()
        {
            //Arrange
            string input = "([{";

            //Assert
            Assert.True(!MultiBracketValidation.Program.MultiBracketValidation(input));
        }

        [Theory]
        [InlineData("{}")]
        [InlineData("{}(){}")]
        [InlineData("()[[Extra Characters]]")]
        [InlineData("(){}[[]]")]
        [InlineData("{}{Code}[Fellows](())")]
        public void ReturnsTrueForVariousStringsWithBalancedBrackets(string input)
        {
            //Assert
            Assert.True(MultiBracketValidation.Program.MultiBracketValidation(input));
        }

        [Theory]
        [InlineData("[({}]")]
        [InlineData("(](")]
        [InlineData("{{(})")]
        [InlineData("(){}[[]")]
        [InlineData("{}{Code}Fellows](())")]
        public void ReturnsFalseForVariousStringsWithUnbalancedBrackets(string input)
        {
            //Assert
            Assert.True(!MultiBracketValidation.Program.MultiBracketValidation(input));
        }
    }
}
