using System;
using System.Collections.Generic;

namespace DigitsToWords.Utilities
{
    public class AmountConvertor
    {
        public string ToWords(decimal chequeAmountInDecimal)
        {
            var chequeAmountInDigits = chequeAmountInDecimal.ToString();

            var dollarAmount = GetDollarsFromAmount(chequeAmountInDigits);
            var centAmount = GetCentsFromAmount(chequeAmountInDigits);

            Dictionary<int, string> dicElements = GetDenominationDetails();

            var digitsToWords = $"{ DollarsInWords(dollarAmount, dicElements)}{Constants.Dollars}";

            digitsToWords += CentsInWords(centAmount, !string.IsNullOrWhiteSpace(digitsToWords));

            return digitsToWords;
        }

        private static string DollarsInWords(string number, Dictionary<int, string> dicElements)
        {
            string words = string.Empty;
            var digit = number;
            foreach (var element in dicElements)
            {
                if (digit.Length > element.Key)
                {
                    words += ConvertNumberToWords(digit, element.Value, element.Key);
                    if (element.Key > 0)
                    {
                        digit = digit.Substring(digit.Length - element.Key);
                        words += Constants.And;
                    }
                    else
                        digit = string.Empty;
                }
            }
            return words;
        }

        private static Dictionary<int, string> GetDenominationDetails()
        {
            var dicElements = new Dictionary<int, string>();
            dicElements.Add(9, " billion ");
            dicElements.Add(6, " million ");
            dicElements.Add(3, " thousand ");
            dicElements.Add(0, "");
            return dicElements;
        }

        private static Func<string, string> GetDollarsFromAmount =
            amount => (amount.IndexOf(".") > 0) ?
            amount.Substring(0, amount.IndexOf(".")) :
            amount;

        private static Func<string, int> GetCentsFromAmount =
            amount =>
            {
                int amountInCents = 0;
                int decimalIndex = amount.IndexOf(".");

                if (decimalIndex > 0)
                {
                    var cents = amount.Substring(decimalIndex + 1);

                    if (cents.Length > 2) cents = cents.Substring(0, 2);

                    int.TryParse(cents, out amountInCents);
                }
                return amountInCents;
            };

        private static Func<int, bool, string> CentsInWords =
            (amount, amountExists) =>
            {
                string cents = string.Empty;
                if (amount > 0)
                {
                    cents = $"{ToTensAndUnits(amount)}{Constants.Cents}";

                    if (amountExists)
                    {
                        cents = $" {Constants.And}{cents}";
                    }
                    return cents;
                }
                return string.Empty;
            };

        private static Func<string, string, int, string> ConvertNumberToWords =
            (number, display, position) => ConvertToWords(number.Substring(0, number.Length - position)) + display;

        private static Func<string, string> ConvertToWords = number =>
        {
            string words = string.Empty;
            int digit;

            int.TryParse(number, out digit);

            words = ToHundred(digit);

            if (!string.IsNullOrWhiteSpace(words))
            {
                digit %= 100;
                words = (digit > 0) ? words += Constants.And : words;
            }

            words += ToTensAndUnits(digit);

            return words;
        };

        private static Func<int, string> ToHundred =
            digit => (digit < Constants.Hundreds_Higher_Limit && digit > Constants.Hundreds_Lower_Limit)
            ? Constants.UnitsMap[digit / 100] + Constants.Hundred
            : string.Empty;

        private static Func<int, string> ToTensAndUnits =
            digit =>
            {
                string words = string.Empty;

                if (digit < 20)
                    words += Constants.UnitsMap[digit];
                else
                {
                    words += Constants.TensMap[digit / 10];
                    if ((digit % 10) > 0)
                        words += Constants.Delimeter + Constants.UnitsMap[digit % 10];
                }
                return words;
            };

    }
}