using TaxCalculator.Entities;
using TaxCalculator.Interface;

namespace TaxCalculator.Infra.TaxRules
{
    public class RetiredRule : ITaxRule
    {
        public int CalculateTaxPercentage(TaxPayer taxPayer, int currentPercentage)
        {
            if (taxPayer.IsRetired)

            {
                return 1;
            }
            return 0;
        }
    }
}
