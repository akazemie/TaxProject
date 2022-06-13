using TaxCalculator.Entities;
using TaxCalculator.Infra;
using TaxCalculator.Interface;

namespace TaxCalculator.Services
{
    public class TaxCalculatorService
    {
        public class IndivisualTaxCalculator
        {
            public int CalculateTaxPercentage(TaxPayer taxPayer)
            {
                var ruleType = typeof(ITaxRule);
                IEnumerable<ITaxRule> rules = GetType().Assembly.GetTypes()
                    .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                    .Select(r => Activator.CreateInstance(r) as ITaxRule);

                var engine = new TaxRuleEngine(rules);

                return engine.CalculateTaxPercentage(taxPayer);
            }
        }
    }
}
