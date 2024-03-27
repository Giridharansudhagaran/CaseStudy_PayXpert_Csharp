using PayXpert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;
namespace PayXpertTestUnit
{
    internal class GrossSalary
    {
        PayrollRepository payrollRepository;
        [SetUp]
        public void SetUp()
        {
            payrollRepository = new PayrollRepository();
        }

        [Test]
        public void CalculateGrossSalaryForEmployee()
        {
            // Arrange
            decimal basicSalary = 5000; // Sample basic salary
            decimal overtimePay = 500; // Sample overtime pay
            decimal expectedGrossSalary = basicSalary + overtimePay; // Expected gross salary

            // Act
            decimal actualGrossSalary = payrollRepository.CalculateGrossSalary(basicSalary, overtimePay);

            // Assert
            Assert.AreEqual(expectedGrossSalary, actualGrossSalary);
        }
    }
}
