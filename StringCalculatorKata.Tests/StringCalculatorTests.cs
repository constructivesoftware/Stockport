using System;
using System.Runtime.Remoting;
using System.Security.Authentication;
using StringCalculatorKata.App;
using Xunit;
using Xunit.Sdk;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Calculate_EmptyString_ReturnsZero()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Action
            var result = calculator.Add("", ',');

            // Assert
            Assert.Equal(result, 0);
        }

        [Fact]
        public void Calculate_SingleNumber_ReturnsSameNumber()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Action
            var result = calculator.Add("1", ',');

            // Assert
            Assert.Equal(result, 1);

        }

        [Fact]
        public void Calculate_TwoNumbers_ReturnsSum()
        {
            //e.g. "1,2" = 3
            // Arrange
            var calculator = new StringCalculator();

            // Action
            var result = calculator.Add("1,2", ',');

            // Assert
            Assert.Equal(result, 3);
        }

        [Fact]
        public void Calculate_FiveNumbers_ReturnsSum()
        {
            //e.g. "1,2,3,4,5" = 15
            // Arrange
            var calculator = new StringCalculator();

            // Action
            var result = calculator.Add("1,2,3,4,5", ',');

            // Assert
            Assert.Equal(result, 15);
        }

        [Fact]
        public void Calculate_CanUseAlternativeDelimiters_ReturnsSum()
        {
            //e.g. "1|2|3" = 6
            // Arrange
            var calculator = new StringCalculator();

            // Action
            var result = calculator.Add("1|2|3", '|');

            // Assert
            Assert.Equal(result, 6);
        }

        [Fact]
        public void Calculate_NumbersLargerThan100_IgnoresOver100sInSum()
        {
            //e.g. "1,2,100" = 3
            // Arrange
            var calculator = new StringCalculator();

            // Action
            var result = calculator.Add("1,2,100", ',');

            // Assert
            Assert.Equal(result, 3);
        }

        [Fact]
        public void Calculate_NonNumericValue_ReturnsZero()
        {
            //e.g. "1,Elephant,6" = 0
            // Arrange
            var calculator = new StringCalculator();

            // Action
            var result = calculator.Add("1,Elephant,6", ',');

            // Assert
            Assert.Equal(result, 0);
        }

        [Fact]
        public void Calculate_FirstSevenInFibonacciSequence_ThrowsCustomFibonacciAlertException()
        {
            //e.g. "0,1,1,2,3,5,8" = FibonacciAlertException!

            // Arrange
            var calculator = new StringCalculator();

            // Action/Assert
            Exception ex = Assert.Throws<FibonacciAlertException>(() => calculator.Add("0,  1,1,2,3    ,5,8", ','));
            
        }
    }
}