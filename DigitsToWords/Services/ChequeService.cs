using DigitsToWords.Models;
using DigitsToWords.Utilities;
using System;

namespace DigitsToWords.Services
{
    public class ChequeService : IChequeService
    {
        public ChequeDetails ProcessConversion(ChequeDetails chequeDetails)
        {
            if (chequeDetails == null || chequeDetails?.AmountInNumbers < 1 || chequeDetails?.AmountInNumbers > 9999999)
                throw new ArgumentOutOfRangeException("AmountInNumbers");

            var amountConvertor = new AmountConvertor();
            chequeDetails.AmountInWords = amountConvertor.ToWords(chequeDetails.AmountInNumbers).FormatAmountToAllCapital();

            return chequeDetails;
        }
    }
}