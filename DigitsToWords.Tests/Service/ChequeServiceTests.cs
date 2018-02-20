using DigitsToWords.Models;
using DigitsToWords.Services;
using DigitsToWords.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DigitsToWords.Tests
{
    [TestClass]
    public class ChequeServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ProcessConversion_InvalidAmount_ThrowsException()
        {
            //Arrange
            var chequeDetails = new ChequeDetails() { Name = "Ramesh", AmountInNumbers = 0 };
            ChequeService chequeService = new ChequeService();

            //Act & Assert
            chequeService.ProcessConversion(chequeDetails);
        }

        [TestMethod]
        public void ProcessConversion_ValidAmount_ReturnsChequeDetails()
        {
            //Arrange
            var expected = "one million and twenty-four thousand and one hundred and one dollars".FormatAmountToAllCapital();
            var chequeDetails = new ChequeDetails() { Name = "Ramesh", AmountInNumbers = 1024101 };
            ChequeService chequeService = new ChequeService();

            //Act
            var actual = chequeService.ProcessConversion(chequeDetails);

            //Assert
            Assert.AreEqual(expected, actual.AmountInWords);
        }
    }
}
