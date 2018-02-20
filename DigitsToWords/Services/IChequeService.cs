using DigitsToWords.Models;

namespace DigitsToWords.Services
{
    public interface IChequeService
    {
        ChequeDetails ProcessConversion(ChequeDetails chequeDetails);
    }
}