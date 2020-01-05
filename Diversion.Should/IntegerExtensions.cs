using System.Text;

namespace Diversion.Should
{
    public static class IntegerExtensions
    {
        public static BinaryNumber ToBinary(this int number, int length)
        {
            var temp = number;
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                stringBuilder.Append(temp & 0x01);
                temp >>= 1;
            }

            return new BinaryNumber(stringBuilder.ToString());
        }
    }
}