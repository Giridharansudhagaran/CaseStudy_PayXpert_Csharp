using PayXpert.Models;
using PayXpert.Utility;
using PayXpert.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    public class TaxRepository
    {
        public TaxRepository()
        {

        }

        public void CalculateTaxInfo(int employeeId, int taxYear)
        {
            try
            {
                List<Tax> taxes = new List<Tax>();
                string query = "SELECT * FROM Tax WHERE EmployeeID = @EmployeeId AND TaxYear = @TaxYear";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@TaxYear", taxYear);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tax tax = new Tax();
                                tax.TaxID = (int)reader["TaxID"];
                                tax.EmployeeID = (int)reader["EmployeeID"];
                                tax.TaxYear = (int)reader["TaxYear"];
                                tax.TaxableIncome = (decimal)reader["TaxableIncome"];

                                // Calculate tax amount based on taxable income
                                decimal taxAmount = CalculateTaxAmount(tax.TaxableIncome);
                                tax.TaxAmount = taxAmount;

                                // Update tax amount in the database
                                UpdateTaxAmountInDatabase(tax.TaxID, taxAmount);

                                taxes.Add(tax);
                            }
                        }
                    }
                }

                if (taxes.Count > 0)
                {
                    Console.WriteLine($"Tax Information for Employee ID: {employeeId} for Tax Year: {taxYear}");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12}",
                        "TaxID", "EmployeeID", "Tax Year", "Taxable Income", "Tax Amount");
                    foreach (var tax in taxes)
                    {
                        Console.WriteLine(tax);
                    }
                }
                else
                {
                    Console.WriteLine($"No tax information found for Employee ID: {employeeId} for Tax Year: {taxYear}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void UpdateTaxAmountInDatabase(int taxId, decimal taxAmount)
        {
            string updateQuery = "UPDATE Tax SET TaxAmount = @TaxAmount WHERE TaxID = @TaxID";

            using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@TaxAmount", taxAmount);
                    command.Parameters.AddWithValue("@TaxID", taxId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"The tax amount {taxAmount} has been updated");
        }

        public decimal CalculateTaxAmount(decimal taxableIncome)
        {
            decimal taxAmount = 0;

            if (taxableIncome > 25000 && taxableIncome <= 30000)
            {
                taxAmount = taxableIncome * 0.05m; // 5% tax rate
            }
            else if (taxableIncome > 30000 && taxableIncome <= 40000)
            {
                taxAmount = taxableIncome * 0.07m; // 7% tax rate
            }
            else if (taxableIncome > 40000 && taxableIncome <= 50000)
            {
                taxAmount = taxableIncome * 0.10m; // 10% tax rate
            }
            else if (taxableIncome > 50000)
            {
                taxAmount = taxableIncome * 0.12m; // 12% tax rate
            }

            return taxAmount;
        }

        public void GetTaxInfoById(int taxId)
        {
            try
            {
                Tax tax = null;
                string query = "SELECT * FROM Tax WHERE TaxID = @TaxID";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaxID", taxId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tax = new Tax();
                                tax.TaxID = (int)reader["TaxID"];
                                tax.EmployeeID = (int)reader["EmployeeID"];
                                tax.TaxYear = (int)reader["TaxYear"];
                                tax.TaxableIncome = (decimal)reader["TaxableIncome"];
                                tax.TaxAmount = (decimal)reader["TaxAmount"];
                            }
                        }
                    }
                }

                if (tax != null)
                {
                    Console.WriteLine($"Tax Information for Tax ID: {taxId}");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12}",
                        "TaxID", "EmployeeID", "Tax Year", "Taxable Income", "Tax Amount");
                    Console.WriteLine(tax);
                }
                else
                {
                    Console.WriteLine($"TaxID : {taxId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void GetTaxesInfoForEmployee(int employeeID)
        {
            try
            {
                List<Tax> taxes = new List<Tax>();
                string query = "SELECT * FROM Tax WHERE EmployeeID = @EmployeeID";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tax tax = new Tax();
                                tax.TaxID = (int)reader["TaxID"];
                                tax.EmployeeID = (int)reader["EmployeeID"];
                                tax.TaxYear = (int)reader["TaxYear"];
                                tax.TaxableIncome = (decimal)reader["TaxableIncome"];
                                tax.TaxAmount = (decimal)reader["TaxAmount"];
                                taxes.Add(tax);
                            }
                        }
                    }
                }

                if (taxes.Count > 0)
                {
                    Console.WriteLine($"Tax Information for Employee ID: {employeeID}");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12}",
                        "TaxID", "EmployeeID", "Tax Year", "Taxable Income", "Tax Amount");
                    foreach (var tax in taxes)
                    {
                        Console.WriteLine(tax);
                    }
                }
                else
                {
                    Console.WriteLine($"No tax information found for Employee ID: {employeeID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void GetTaxesInfoForYear(int taxYear)
        {
            try
            {
                List<Tax> taxes = new List<Tax>();
                string query = "SELECT * FROM Tax WHERE TaxYear = @TaxYear";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaxYear", taxYear);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tax tax = new Tax();
                                tax.TaxID = (int)reader["TaxID"];
                                tax.EmployeeID = (int)reader["EmployeeID"];
                                tax.TaxYear = (int)reader["TaxYear"];
                                tax.TaxableIncome = (decimal)reader["TaxableIncome"];
                                tax.TaxAmount = (decimal)reader["TaxAmount"];
                                taxes.Add(tax);
                            }
                        }
                    }
                }

                if (taxes.Count > 0)
                {
                    Console.WriteLine($"Tax Information for Tax Year: {taxYear}");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12}",
                        "TaxID", "EmployeeID", "Tax Year", "Taxable Income", "Tax Amount");
                    foreach (var tax in taxes)
                    {
                        Console.WriteLine(tax);
                    }
                }
                else
                {
                    Console.WriteLine($"No tax information found for Tax Year: {taxYear}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        public void GetAllTaxInfo()
        {
            try
            {
                List<Tax> taxes = new List<Tax>();
                string query = "SELECT * FROM Tax";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tax tax = new Tax();
                                tax.TaxID = (int)reader["TaxID"];
                                tax.EmployeeID = (int)reader["EmployeeID"];
                                tax.TaxYear = (int)reader["TaxYear"];
                                tax.TaxableIncome = (decimal)reader["TaxableIncome"];
                                tax.TaxAmount = (decimal)reader["TaxAmount"];
                                taxes.Add(tax);
                            }
                        }
                    }
                }

                if (taxes.Count > 0)
                {
                    Console.WriteLine("Tax Information for all employees:\n");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12}",
                        "TaxID", "EmployeeID", "Tax Year", "Taxable Income", "Tax Amount");
                    foreach (var tax in taxes)
                    {
                        Console.WriteLine(tax);
                    }
                }
                else
                {
                    Console.WriteLine("No tax information found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}
