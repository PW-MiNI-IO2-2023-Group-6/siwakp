using TDD_warsztat;

namespace UnitTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.Calculate("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        [InlineData("121", 121)]
        [InlineData("42", 42)]
        public void StringWithNumberReturnsItsValue(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12,45", 57)]
        [InlineData("3,45", 48)]
        [InlineData("5,42", 47)]
        [InlineData("0,0", 0)]
        public void CommaSeparatedNumbersReturnSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n45", 57)]
        [InlineData("3\n45", 48)]
        [InlineData("5\n42", 47)]
        [InlineData("0\n0", 0)]
        public void NewlineSeparatedNumbersReturnSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n45,5", 62)]
        [InlineData("2,3\n45", 50)]
        [InlineData("5\n42,0", 47)]
        [InlineData("0\n0\n5", 5)]
        public void CommaOrNewlineSeparatedNumbersReturnSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n4005,5", 17)]
        [InlineData("2,3\n45", 50)]
        [InlineData("5\n42,1001", 47)]
        [InlineData("0\n0\n5", 5)]
        [InlineData("1001", 0)]
        public void NumbersBiggerThanThousandIgnored(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-2,3\n45")]
        [InlineData("-5\n42,-1001")]
        [InlineData("0\n0\n-5")]
        public void NegativeNumbersThrowException(string str)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Calculate(str));
        }

        [Theory]
        [InlineData("//%\n12\n4005%5", 17)]
        [InlineData("// \n2,3 45", 50)]
        [InlineData("5\n42,1001", 47)]
        [InlineData("//g\n0g0\n5", 5)]
        [InlineData("1001", 0)]
        public void SpecialCharacterActsAsSeparator(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }
    }
}