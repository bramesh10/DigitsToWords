using System;

namespace DigitsToWords.Models
{
    public class ChequeDetails
    {
        public string Name { get; set; }
        public DateTime DateIssued { get; set; }
        public decimal AmountInNumbers { get; set; }
        public string AmountInWords { get; set; }
    }
}