using DigitsToWords.Controllers;
using DigitsToWords.Models;
using DigitsToWords.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DigitsToWords.Tests.Controller
{
    [TestClass]
    public class ChequeControllerTests
    {
        private ChequeDetails _chequeDetails;
        private ChequeController _chequeController;
        Mock<IChequeService> mockService;

        [TestInitialize]
        public void Initialize()
        {
            _chequeDetails = new ChequeDetails();
            mockService = new Moq.Mock<IChequeService>();

            _chequeController = new ChequeController(mockService.Object);

            _chequeController.Request = new HttpRequestMessage();
            _chequeController.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void ProcessDetails_NameIsEmpty_MustReturnBadRequest()
        {
            // Arrange

            _chequeDetails.Name = "";
            _chequeDetails.AmountInNumbers = -12;

            // Act
            var result = _chequeController.ProcessDetails(_chequeDetails);
            var chequeResult = result as BadRequestErrorMessageResult;

            // Assert
            Assert.IsTrue(chequeResult.Message.Equals(Utilities.Constants.Name_Error_Message));
        }

        [TestMethod]
        public void ProcessDetails_InvalidAmount_MustReturnBadRequest()
        {
            // Arrange
            _chequeDetails.Name = "Ramesh";
            _chequeDetails.AmountInNumbers = -12;

            // Act
            var result = _chequeController.ProcessDetails(_chequeDetails);
            var chequeResult = result as BadRequestErrorMessageResult;

            // Assert
            Assert.IsTrue(chequeResult.Message.Equals(Utilities.Constants.Number_Error_Message));
        }

        [TestMethod]
        public void ProcessDetails_ValidAmount_ReturnsChequeDetails()
        {
            // Arrange
            _chequeDetails.Name = "Ramesh";
            _chequeDetails.AmountInNumbers = 1101010;
            mockService.Setup(meth => meth.ProcessConversion(It.IsAny<ChequeDetails>())).Returns(_chequeDetails);


            // Act
            var result = _chequeController.ProcessDetails(_chequeDetails);
            var chequeResult = result as OkNegotiatedContentResult<ChequeDetails>;

            // Assert
            Assert.IsTrue(chequeResult.Content.Name.Equals("Ramesh"));
            Assert.IsTrue(chequeResult.Content.AmountInNumbers.Equals(1101010));
            mockService.Verify(mock => mock.ProcessConversion(It.IsAny<ChequeDetails>()), Times.Once());
            mockService.VerifyAll();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _chequeDetails = null;
            _chequeController = null;
        }
    }
}
