using TaxCalculator.Entities;

namespace TaxCalculator.Interface
{
    public interface ITaxRule
    {
        int CalculateTaxPercentage(TaxPayer taxPayer, int currentPercentage);
    }
}
