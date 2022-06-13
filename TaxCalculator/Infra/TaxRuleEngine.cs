using TaxCalculator.Entities;
using TaxCalculator.Interface;

namespace TaxCalculator.Infra
{
    public class TaxRuleEngine
    {
        private List<ITaxRule> _rules = new List<ITaxRule>();
        public TaxRuleEngine(IEnumerable<ITaxRule> rules)
        {
            _rules.AddRange(rules);
        }

        public int CalculateTaxPercentage(TaxPayer taxPayer)
        {
            int TaxPercentage = 0;
            foreach (var rule in _rules)
            {
                TaxPercentage = Math.Max(TaxPercentage, rule.CalculateTaxPercentage(taxPayer, TaxPercentage));
            }
            return TaxPercentage;
        }
    }
}
