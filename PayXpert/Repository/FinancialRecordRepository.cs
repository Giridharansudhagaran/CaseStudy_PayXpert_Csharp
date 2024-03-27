using PayXpert.Utility;
using PayXpert.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Models;

namespace PayXpert.Repository
{
    internal class FinancialRecordRepository
    {
        public FinancialRecordRepository()
        {
        
        }

        public void AddFinancialRecordInfo(int employeeId, string description, decimal amount, string recordType)
        {
            try
            {
                string query = "INSERT INTO FinancialRecord (EmployeeId, RecordDate, Description, Amount, RecordType) VALUES (@EmployeeId, @RecordDate, @Description, @Amount, @RecordType)";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        command.Parameters.AddWithValue("@RecordDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@RecordType", recordType);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Financial record of Employee id : {employeeId} added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add financial record.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void GetFinancialRecordInfoById(int recordId)
        {
            try
            {
                FinancialRecord financialRecord = null;
                string query = "SELECT * FROM FinancialRecord WHERE RecordID = @RecordID";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecordID", recordId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                financialRecord = new FinancialRecord();
                                financialRecord.RecordID = (int)reader["RecordID"];
                                financialRecord.EmployeeId = (int)reader["EmployeeId"];
                                financialRecord.RecordDate = (DateTime)reader["RecordDate"];
                                financialRecord.Description = (string)reader["Description"];
                                financialRecord.Amount = (decimal)reader["Amount"];
                                financialRecord.RecordType = (string)reader["RecordType"];
                            }
                        }
                    }
                }

                if (financialRecord != null)
                {
                    Console.WriteLine($"Financial Record Information for Record ID: {recordId}\n");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12}",
                        "RecordID", "EmployeeID", "Record Date", "Description", "Amount", "Record Type");
                    Console.WriteLine(financialRecord);
                }
                else
                {
                    Console.WriteLine($"Financial record ID :  {recordId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void GetFinancialRecordsInfoForDate(DateTime recordDate)
        {
            try
            {
                List<FinancialRecord> financialRecords = new List<FinancialRecord>();
                string query = "SELECT * FROM FinancialRecord WHERE RecordDate = @RecordDate";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecordDate", recordDate);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FinancialRecord financialRecord = new FinancialRecord();
                                financialRecord.RecordID = (int)reader["RecordID"];
                                financialRecord.EmployeeId = (int)reader["EmployeeId"];
                                financialRecord.RecordDate = (DateTime)reader["RecordDate"];
                                financialRecord.Description = (string)reader["Description"];
                                financialRecord.Amount = (decimal)reader["Amount"];
                                financialRecord.RecordType = (string)reader["RecordType"];
                                financialRecords.Add(financialRecord);
                            }
                        }
                    }
                }

                if (financialRecords.Count > 0)
                {
                    Console.WriteLine($"Financial Records Information for Date: {recordDate:MM/dd/yyyy}\n");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12}",
                        "RecordID", "EmployeeID", "Record Date", "Description", "Amount", "Record Type");
                    foreach (var financialRecord in financialRecords)
                    {
                        Console.WriteLine(financialRecord);
                    }
                }
                else
                {
                    Console.WriteLine($"No financial records found for date: {recordDate:MM/dd/yyyy}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void GetFinancialRecordsInfoForEmployee(int employeeId)
        {
            try
            {
                List<FinancialRecord> financialRecords = new List<FinancialRecord>();
                string query = "SELECT * FROM FinancialRecord WHERE EmployeeId = @EmployeeId";

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
                                FinancialRecord financialRecord = new FinancialRecord();
                                financialRecord.RecordID = (int)reader["RecordID"];
                                financialRecord.EmployeeId = (int)reader["EmployeeId"];
                                financialRecord.RecordDate = (DateTime)reader["RecordDate"];
                                financialRecord.Description = (string)reader["Description"];
                                financialRecord.Amount = (decimal)reader["Amount"];
                                financialRecord.RecordType = (string)reader["RecordType"];
                                financialRecords.Add(financialRecord);
                            }
                        }
                    }
                }

                if (financialRecords.Count > 0)
                {
                    Console.WriteLine($"Financial Records Information for Employee ID: {employeeId}\n");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12}",
                        "RecordID", "EmployeeID", "Record Date", "Description", "Amount", "Record Type");
                    foreach (var financialRecord in financialRecords)
                    {
                        Console.WriteLine(financialRecord);
                    }
                }
                else
                {
                    Console.WriteLine($"No financial records found for Employee ID: {employeeId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void GetAllFinancialRecordInfo()
        {
            try
            {
                List<FinancialRecord> financialRecords = new List<FinancialRecord>();
                string query = "SELECT * FROM FinancialRecord";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FinancialRecord financialRecord = new FinancialRecord();
                                financialRecord.RecordID = (int)reader["RecordID"];
                                financialRecord.EmployeeId = (int)reader["EmployeeId"];
                                financialRecord.RecordDate = (DateTime)reader["RecordDate"];
                                financialRecord.Description = (string)reader["Description"];
                                financialRecord.Amount = (decimal)reader["Amount"];
                                financialRecord.RecordType = (string)reader["RecordType"];
                                financialRecords.Add(financialRecord);
                            }
                        }
                    }
                }

                if (financialRecords.Count > 0)
                {
                    Console.WriteLine("Financial Record Information for all employees:\n");
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12}",
                        "RecordID", "EmployeeId", "Record Date", "Description", "Amount", "Record Type");
                    foreach (var financialRecord in financialRecords)
                    {
                        Console.WriteLine(financialRecord);
                    }
                }
                else
                {
                    Console.WriteLine("No financial record information found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
