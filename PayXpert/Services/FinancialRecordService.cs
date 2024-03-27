using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;
using PayXpert.Exceptions;
using PayXpert.Models;

namespace PayXpert.Services
{
    internal class FinancialRecordService:IFinancialRecordService
    {
        FinancialRecordRepository financialRecordRepository;

        public FinancialRecordService()
        {
            financialRecordRepository = new FinancialRecordRepository();
        }

        public void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {

            financialRecordRepository.AddFinancialRecordInfo(employeeId, description, amount, recordType);
     
        }

        public void GetFinancialRecordById(int recordId)
        {
            financialRecordRepository.GetFinancialRecordInfoById(recordId);
        }

        public void GetFinancialRecordsForDate(DateTime recordDate)
        {

            financialRecordRepository.GetFinancialRecordsInfoForDate(recordDate);

        }

        public void GetFinancialRecordsForEmployee(int employeeId)
        {
            financialRecordRepository.GetFinancialRecordsInfoForEmployee(employeeId);
        }

        public void GetFinancialRecord()
        {
            financialRecordRepository.GetAllFinancialRecordInfo();
        }

        public void FinancialRecordMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Financial Record Management");
                Console.WriteLine("---------------------");
                Console.WriteLine("1: Add Financial Record\n2: Get Financial Record By ID\n3: Get Financial Records For Employee\n4: Get Financial Records For Date\n5: Get All Financial Info\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter Employee ID: ");
                            int empId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Description: ");
                            string description = Console.ReadLine();
                            Console.WriteLine("Enter Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Record Type: ");
                            string recordType = Console.ReadLine();
                            AddFinancialRecord(empId, description, amount, recordType);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Record ID: ");
                            int rId = int.Parse(Console.ReadLine());
                            GetFinancialRecordById(rId);
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
                            GetFinancialRecordsForEmployee(eId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Enter Record Date (yyyy-mm-dd): ");
                            DateTime rDate = DateTime.Parse(Console.ReadLine());
                            GetFinancialRecordsForDate(rDate);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 5:
                        GetFinancialRecord();
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
