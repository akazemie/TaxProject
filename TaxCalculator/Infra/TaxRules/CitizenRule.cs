using TaxCalculator.Entities;
using TaxCalculator.Interface;

namespace TaxCalculator.Infra.TaxRules
{
    public class CitizenRule : ITaxRule
    {
        public int CalculateTaxPercentage(TaxPayer taxPayer, int currentPercentage)
        {
            if (!taxPayer.TaxCitizen)
            {
                throw new InvalidOperationException("No TAX Calculation for NON-TAX Residents");
            }
            return 0;
        }
    }
}
