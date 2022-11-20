using StringCalculator;
using System;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1, 2", 3)]
        public void Add_GivenSimpleString_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        public void Add_GivenNewLine_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        public void Add_GivenDefinedDelimiter_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("//[*][%][^]\n1*2%3,4^5", 15)]
        public void Allows_Multiple_Delimiters(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("1, -2", "-2")]
        public void Throws_Exception_When_Numbers_Are_Negative(string input, string expected)
        {
            Action action = () => Calculator.Add(input);
            Exception ex = Assert.Throws<Exception>(action);
            Assert.Equal($"Negative Numbers are not allowed. '{expected}'", ex.Message);

        }
    }
}
