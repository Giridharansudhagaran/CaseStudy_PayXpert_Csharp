using PayXpert.Models;
using PayXpert.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Exceptions;

namespace PayXpert.Repository
{
    public class PayrollRepository
    {
        public PayrollRepository()
        {
        }

        public decimal CalculateGrossSalary(decimal basicSalary, decimal overtimePay)
        {
            return basicSalary + overtimePay;
        }

        public void GeneratePayrollInfo(int employeeId, DateTime startDate, DateTime endDate, decimal basicSalary, decimal deductions, decimal overtimePay)
        {
            try
            {

                string query = @"INSERT INTO Payroll (EmployeeId, PayPeriodStartDate, PayPeriodEndDate, BasicSalary, Deductions, OvertimePay, NetSalary) 
                         VALUES (@EmployeeId, @StartDate, @EndDate, @BasicSalary, @Deductions, @OvertimePay, @NetSalary)";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@BasicSalary", basicSalary);
                        command.Parameters.AddWithValue("@Deductions", deductions);
                        command.Parameters.AddWithValue("@OvertimePay", overtimePay);
                        command.Parameters.AddWithValue("@NetSalary", CalculateNetSalary(basicSalary, deductions, overtimePay));

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Payroll information for Employee Id : {employeeId} generated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to generate payroll information.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public decimal CalculateNetSalary(decimal basicSalary, decimal deductions, decimal overtimePay)
        {
            decimal netSalary = (basicSalary - deductions) + overtimePay;
            return netSalary;
        }

        public void GetPayrollInfoById(int payrollId)
        {
            try
            {
                Payroll payroll = null;
                string query = "SELECT * FROM Payroll WHERE PayrollId = @PayrollId";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PayrollId", payrollId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                payroll = new Payroll();
                                payroll.PayrollId = (int)reader["PayrollId"];
                                payroll.EmployeeId = (int)reader["EmployeeId"];
                                payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                                payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];
                                payroll.BasicSalary = (decimal)reader["BasicSalary"];
                                payroll.OvertimePay = (decimal)reader["OvertimePay"];
                                payroll.Deductions = (decimal)reader["Deductions"];
                                payroll.NetSalary = (decimal)reader["NetSalary"];
                            }
                        }
                    }
                }

                if (payroll != null)
                {
                    Console.WriteLine("Payroll Information for ID: {0}", payrollId);
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12} {6,-12} {7,-12}",
                        "PayrollID", "EmployeeID", "Start Date", "End Date", "Basic Salary", "Overtime Pay", "Deductions", "Net Salary");
                    Console.WriteLine(payroll);
                }
                else
                {
                    Console.WriteLine($"Payroll with ID {payrollId} not found.");
                }
            }
            catch (Exception ex)
            {
                 throw new DatabaseConnectionException("An error occurred: " + ex.Message);
            }
        }

        public void GetPayrollsInfoForEmployee(int employeeId)
        {

            List<Payroll> payrolls = new List<Payroll>();
            string query = "SELECT * FROM Payroll WHERE EmployeeId = @EmployeeId";

            using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Payroll payroll = new Payroll();
                            payroll.PayrollId = (int)reader["PayrollId"];
                            payroll.EmployeeId = (int)reader["EmployeeId"];
                            payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                            payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];
                            payroll.BasicSalary = (decimal)reader["BasicSalary"];
                            payroll.OvertimePay = (decimal)reader["OvertimePay"];
                            payroll.Deductions = (decimal)reader["Deductions"];
                            payroll.NetSalary = (decimal)reader["NetSalary"];
                            payrolls.Add(payroll);
                        }
                    }
                }
            }

            if (payrolls.Count > 0)
            {
                Console.WriteLine($"Payroll Information for Employee ID: {employeeId}");
                Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12} {6,-12} {7,-12}",
                    "PayrollID", "EmployeeID", "Start Date", "End Date", "Basic Salary", "Overtime Pay", "Deductions", "Net Salary");
                foreach (var payroll in payrolls)
                {
                    Console.WriteLine(payroll);
                }
            }
            else
            {
                Console.WriteLine($"No payroll information found for Employee ID: {employeeId}");
            }
        }

        public void GetPayrollsInfoForPeriod(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Payroll> payrolls = new List<Payroll>();
                string query = "SELECT * FROM Payroll WHERE PayPeriodStartDate >= @StartDate AND PayPeriodEndDate <= @EndDate";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Payroll payroll = new Payroll();
                                payroll.PayrollId = (int)reader["PayrollId"];
                                payroll.EmployeeId = (int)reader["EmployeeId"];
                                payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                                payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];
                                payroll.BasicSalary = (decimal)reader["BasicSalary"];
                                payroll.OvertimePay = (decimal)reader["OvertimePay"];
                                payroll.Deductions = (decimal)reader["Deductions"];
                                payroll.NetSalary = (decimal)reader["NetSalary"];
                                payrolls.Add(payroll);
                            }
                        }
                    }
                }

                if (payrolls.Count > 0)
                {
                    Console.WriteLine($"Payroll Information for Period: {startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12} {6,-12} {7,-12}",
                        "PayrollID", "EmployeeID", "Start Date", "End Date", "Basic Salary", "Overtime Pay", "Deductions", "Net Salary");
                    foreach (var payroll in payrolls)
                    {
                        Console.WriteLine(payroll);
                    }
                }
                else
                {
                    Console.WriteLine($"No payroll information found for the period: {startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}");
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("An error occurred: " + ex.Message);
            }
        }

        public void GetAllPayrollInfo()
        {
            try
            {
                List<Payroll> payrolls = new List<Payroll>();
                string query = "SELECT * FROM Payroll";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Payroll payroll = new Payroll();
                                payroll.PayrollId = (int)reader["PayrollId"];
                                payroll.EmployeeId = (int)reader["EmployeeId"];
                                payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                                payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];
                                payroll.BasicSalary = (decimal)reader["BasicSalary"];
                                payroll.OvertimePay = (decimal)reader["OvertimePay"];
                                payroll.Deductions = (decimal)reader["Deductions"];
                                payroll.NetSalary = (decimal)reader["NetSalary"];
                                payrolls.Add(payroll);
                            }
                        }
                    }
                }

                if (payrolls.Count > 0)
                {
                    Console.WriteLine("Payroll Information for all employees:\n");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12} {6,-12} {7,-12}",
                        "PayrollID", "EmployeeID", "Start Date", "End Date", "Basic Salary", "Overtime Pay", "Deductions", "Net Salary");
                    foreach (var payroll in payrolls)
                    {
                        Console.WriteLine(payroll);
                    }
                }
                else
                {
                    Console.WriteLine("No payroll information found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
