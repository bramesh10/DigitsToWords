using DigitsToWords.Models;
using DigitsToWords.Services;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace DigitsToWords.Controllers
{
    public class ChequeController : ApiController
    {
        private readonly IChequeService _chequeService;
        public ChequeController(IChequeService chequeService)
        {
            _chequeService = chequeService;
        }

        [HttpPost]
        public IHttpActionResult ProcessDetails(ChequeDetails chequeDetails)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s-]+$");
            if ((chequeDetails.Name == null) || (chequeDetails.Name == string.Empty) || (!regex.IsMatch(chequeDetails.Name)))
            {
                return BadRequest(Utilities.Constants.Name_Error_Message);
            }
            regex = new Regex(@"^[0-9,\.]+$");
            if (!regex.IsMatch(chequeDetails.AmountInNumbers.ToString()) || chequeDetails.AmountInNumbers <= 0 || chequeDetails.AmountInNumbers > 9999999)
            {
                return BadRequest(Utilities.Constants.Number_Error_Message);
            }

            chequeDetails = _chequeService.ProcessConversion(chequeDetails);

            return Ok(chequeDetails);
        }

    }
}
