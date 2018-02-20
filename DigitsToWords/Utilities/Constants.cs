namespace DigitsToWords.Utilities
{
    public class Constants
    {
        public static string[] UnitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        public static string[] TensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        public static int Hundreds_Lower_Limit = 99;
        public static int Hundreds_Higher_Limit = 999;
        public static string Hundred = " hundred ";
        public static string Delimeter = "-";
        public static string And = "and ";
        public static string Dollars = " dollars";
        public static string Cents = " cents";
        public static string Name_Error_Message = "Name cannot be null.";
        public static string Number_Error_Message = "Amount must be numeric value from 1 up to 9999999";
    }
}