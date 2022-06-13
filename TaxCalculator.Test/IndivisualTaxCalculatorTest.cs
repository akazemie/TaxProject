using TaxCalculator.Entities;

namespace TaxCalculator.Test
{
    public class IndivisualTaxCalculatorTest
    {
        private IndivisualTaxCalculator _calculator = new IndivisualTaxCalculator();

        [Fact]
        public void Retired_Taxpayer_SHOULD_Pay_ONE_Percent_Tax()
        {
            //ARRANGE
            TaxPayer taxPayer = new TaxPayer
            {
                TaxCitizen = true,
                HasDisability = false,
                IsRetired = true
            };

            //Act
            var result = _calculator.CalculateTaxPercentage(taxPayer);

            //Assert
            Assert.Equal(1, result);
        }
    }
}