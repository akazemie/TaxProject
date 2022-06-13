using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Entities;

namespace TaxCalculator
{
    public interface ITaxRule
    {
        int CalculateTaxPercentage(TaxPayer taxPayer, int currentPercentage);
    }

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
