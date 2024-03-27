using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpertTestUnit
{
    internal class MultiplePayrollProcess
    {
        private PayrollRepository payrollRepository;

        [SetUp]
        public void Setup()
        {
            payrollRepository = new PayrollRepository();
        }

        [Test]
        public void ProcessPayrollForMultipleEmployees_Success()
        {
            // Arrange
            int employee1Id = 1;
            int employee2Id = 2;
            DateTime startDate = new DateTime(2024, 3, 1);
            DateTime endDate = new DateTime(2024, 3, 15);
            decimal basicSalary = 2000;
            decimal deductions = 500;
            decimal overtimePay = 300;

            // Act
            payrollRepository.GeneratePayrollInfo(employee1Id, startDate, endDate, basicSalary, deductions, overtimePay);
            payrollRepository.GeneratePayrollInfo(employee2Id, startDate, endDate, basicSalary, deductions, overtimePay);

            //Assert
            Assert.DoesNotThrow(() => payrollRepository.GeneratePayrollInfo(employee1Id, startDate, endDate, basicSalary, deductions, overtimePay));
            Assert.DoesNotThrow(() => payrollRepository.GeneratePayrollInfo(employee2Id, startDate, endDate, basicSalary, deductions, overtimePay));
        }
    }
}
