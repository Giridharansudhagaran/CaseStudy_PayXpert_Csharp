using PayXpert.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;

namespace PayXpertTestUnit
{
    internal class CalculateTaxTest
    {
        TaxRepository taxRepository;

        [SetUp]
        public void Setup()
        {
            taxRepository = new TaxRepository();    
        }

        [Test]
        public void VerifyTaxCalculationForHighIncomeEmployee()
        {
            // Arrange
            decimal taxableIncome = 65000.00m; // Considered as high income
            decimal expectedTaxAmount = 7800.00m; // Expected tax amount for a taxable income of 60000 (12% of 60000)

            // Act
            decimal taxAmount = taxRepository.CalculateTaxAmount(taxableIncome);

            // Assert
            Assert.AreEqual(expectedTaxAmount, taxAmount);
        }
    }
}
