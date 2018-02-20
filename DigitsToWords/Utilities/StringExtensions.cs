using System.Linq;

namespace DigitsToWords.Utilities
{
    public static class StringExtensions
    {
        public static string FormatAmountToFirstCapital(this string Amount)
        {
            return Amount.First().ToString().ToUpper() + Amount.Substring(1);
        }
        public static string FormatAmountToAllCapital(this string Amount)
        {
            return Amount.ToUpper();
        }
    }
}