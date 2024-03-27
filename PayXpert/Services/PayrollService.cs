using PayXpert.Exceptions;
using PayXpert.Models;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Services
{
    public class PayrollService : IPayrollService
    {
        PayrollRepository payrollRepository;

        public PayrollService() 
        {
           payrollRepository = new PayrollRepository();
        }

        public void GeneratePayroll(int employeeId, DateTime startDate, DateTime endDate,decimal basicsalary,decimal deductions, decimal overtimepay)
        {
            payrollRepository.GeneratePayrollInfo(employeeId, startDate, endDate,basicsalary,deductions,overtimepay);
        }

        public void GetPayrollById(int payrollId)
        {
            payrollRepository.GetPayrollInfoById(payrollId);
        }

        public void GetPayrollsForEmployee(int employeeId)
        {
            payrollRepository.GetPayrollsInfoForEmployee(employeeId);
        }

        public void GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            payrollRepository.GetPayrollsInfoForPeriod(startDate, endDate);
        }
        
        public void GetPayroll()
        {
            payrollRepository.GetAllPayrollInfo();
        }

        public void PayrollMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Payroll Management");
                Console.WriteLine("---------------------");
                Console.WriteLine("1: Generate Payroll\n2: Get Payroll By ID\n3: Get Payrolls For Employee\n4: Get Payrolls For Period\n5: Get All Payroll Info\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter Employee ID: ");
                            int employeeId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Start Date (yyyy-mm-dd): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter End Date (yyyy-mm-dd): ");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the basic salary: ");
                            decimal basicsalary = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the deductions: ");
                            decimal deductions = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the overtime pay: ");
                            decimal overtimepay = decimal.Parse(Console.ReadLine());
                            GeneratePayroll(employeeId, startDate, endDate, basicsalary, deductions, overtimepay);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Payroll ID: ");
                            int payrollId = int.Parse(Console.ReadLine());
                            GetPayrollById(payrollId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Enter Employee ID: ");
                            int empId = int.Parse(Console.ReadLine());
                            GetPayrollsForEmployee(empId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Example record '2024-02-01', '2024-02-29'");
                            Console.WriteLine("Enter Start Date (yyyy-mm-dd): ");
                            DateTime sDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter End Date (yyyy-mm-dd): ");
                            DateTime eDate = DateTime.Parse(Console.ReadLine());
                            GetPayrollsForPeriod(sDate, eDate);
                        }
                        catch ( Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 5:
                        GetPayroll();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 6);
        }
    }
}
