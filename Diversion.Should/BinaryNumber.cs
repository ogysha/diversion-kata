using System;
using System.Collections.Generic;
using System.Linq;

namespace Diversion.Should
{
    public class BinaryNumber
    {
        public enum Digit
        {
            Zero = 0,
            One = 1
        }

        private readonly string _stringRepresentation;

        public BinaryNumber(string stringRepresentation)
        {
            if (!ValidateStringRepresentation(stringRepresentation))
                throw new ArgumentException(nameof(stringRepresentation));

            _stringRepresentation = stringRepresentation;
        }

        private bool ValidateStringRepresentation(string stringRepresentation)
        {
            return stringRepresentation.ToCharArray()
                .All(IsBinaryDigit);
        }

        private static bool IsBinaryDigit(char c)
        {
            return c == '0' || c == '1';
        }

        public static IEnumerable<BinaryNumber> GetNumbersWithNonAdjacentDigits(int digitsCount, Digit digit)
        {
            return GenerateNumbers(digitsCount)
                .Where(b => !b.HasAdjacent(digit));
        }

        private bool HasAdjacent(Digit digit)
        {
            var nonRepeatingValue = (char) ('0' + digit);
            for (var i = 0; i < _stringRepresentation.Length - 1; i++)
                if (_stringRepresentation.ElementAt(i) == nonRepeatingValue
                    && _stringRepresentation.ElementAt(i) == _stringRepresentation.ElementAt(i + 1))
                    return true;

            return false;
        }

        private static IEnumerable<BinaryNumber> GenerateNumbers(int n)
        {
            return Enumerable.Range(0, (int) Math.Pow(2, n))
                .Select(i => i.ToBinary(n));
        }

        public override string ToString()
        {
            return _stringRepresentation;
        }
    }
}