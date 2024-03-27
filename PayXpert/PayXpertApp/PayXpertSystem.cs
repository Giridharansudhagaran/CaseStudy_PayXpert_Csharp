using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;
using PayXpert.Services;

namespace PayXpert.PayXpertApp
{
    internal class PayXpertSystem
    {
        EmployeeService employeeService;
        PayrollService payrollService;
        TaxService taxService;
        FinancialRecordService financialRecordService;

        public PayXpertSystem()
        {
            employeeService = new EmployeeService();
            payrollService = new PayrollService();
            taxService = new TaxService();
            financialRecordService = new FinancialRecordService();
        }

        public void MainMenu()
        {
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine(".................");
                Console.WriteLine($"1:: Employee\n2:: Payroll\n3:: Tax\n4:: Fiancial Record\n5:: Exit\n");
                Console.WriteLine("Enter your choice: ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        employeeService.EmployeeMenu();
                        break;

                    case 2:
                        payrollService.PayrollMenu();
                        break;

                    case 3:
                        taxService.TaxMenu();
                        break;

                    case 4:
                        financialRecordService.FinancialRecordMenu();
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again...");
                        break;
                }
            } while (option != 5);
        }
    }
}
