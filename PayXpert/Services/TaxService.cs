using PayXpert.Exceptions;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Services
{
    internal class TaxService:ITaxService
    {
        TaxRepository taxRepository;

        public TaxService() 
        { 
            taxRepository = new TaxRepository();
        }

        public void CalculateTax(int employeeId, int taxYear)
        {
             taxRepository.CalculateTaxInfo(employeeId, taxYear);
        }

        public void GetTaxById(int taxId)
        {
            taxRepository.GetTaxInfoById(taxId);
        }

        public void GetTaxesForEmployee(int employeeID)
        {
            taxRepository.GetTaxesInfoForEmployee(employeeID);
        }

        public void GetTaxesForYear(int taxYear)
        {
            taxRepository.GetTaxesInfoForYear(taxYear);
        }

        public void GetAllTax()
        {
            taxRepository.GetAllTaxInfo();
        }

        public void TaxMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Tax Management");
                Console.WriteLine("---------------------");
                Console.WriteLine("1: Calculate Tax\n2: Get Tax By ID\n3: Get Taxes For Employee\n4: Get Taxes For Year\n5: Get All Tax Info\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter Employee ID: ");
                            int empId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Tax Year: ");
                            int taxYear = int.Parse(Console.ReadLine());
                            CalculateTax(empId, taxYear);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Tax ID: ");
                            int taxId = int.Parse(Console.ReadLine());
                            GetTaxById(taxId);
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
                            int eId = int.Parse(Console.ReadLine());
                            GetTaxesForEmployee(eId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Enter Tax Year: ");
                            int tYear = int.Parse(Console.ReadLine());
                            GetTaxesForYear(tYear);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 5:
                        GetAllTax();
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
