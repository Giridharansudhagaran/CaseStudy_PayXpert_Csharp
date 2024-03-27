using PayXpert.Repository;
namespace PayXpertTestUnit
{
    public class NetSalaryTest
    {
        private PayrollRepository payrollRepository;

        [SetUp]
        public void Setup()
        {
            payrollRepository = new PayrollRepository();
        }

        [Test]
        public void CalculateNetSalaryAfterDeductions()
        {
    
            decimal basicSalary = 5000.00m;
            decimal deductions = 200.00m;
            decimal overtimePay = 100.00m;
            decimal expectedNetSalary = 4900.00m; 

            // Act
            decimal netSalary = payrollRepository.CalculateNetSalary(basicSalary, deductions, overtimePay);

            // Assert
            Assert.AreEqual(expectedNetSalary, netSalary);
        }
    }
}