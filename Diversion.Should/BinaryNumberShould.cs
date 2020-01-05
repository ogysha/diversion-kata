using System.Linq;
using Xunit;

namespace Diversion.Should
{
    public class BinaryNumberShould
    {
        [Theory]
        [InlineData(3, 2)]
        [InlineData(5, 3)]
        [InlineData(8, 4)]
        public void Return_number_of_variations_of_non_adjacent_bits_of_1_for_binary_numbers(int expected, int digitsCount)
        {
            var nonOneAdjacentNumbers = BinaryNumber.GetNumbersWithNonAdjacentDigits(digitsCount, BinaryNumber.Digit.One);

            Assert.Equal(expected, nonOneAdjacentNumbers.Count());
        }
    }
}