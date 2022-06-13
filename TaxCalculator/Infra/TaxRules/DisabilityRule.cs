using TaxCalculator.Entities;
using TaxCalculator.Interface;

namespace TaxCalculator.Infra.TaxRules
{
    public class DisabilityRule : ITaxRule
    {
        public int CalculateTaxPercentage(TaxPayer taxPayer, int currentPercentage)
        {
            if (taxPayer.HasDisability)
            {
                return 0;
            }
            return 0;
        }
    }
}
