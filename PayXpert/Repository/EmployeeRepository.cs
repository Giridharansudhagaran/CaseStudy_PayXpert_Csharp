using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Models;
using PayXpert.Utility;
using PayXpert.Exceptions;
using System.Net.Http.Headers;

namespace PayXpert.Repository
{
    public class EmployeeRepository
    {
        public EmployeeRepository()
        {

        }

        public void GetAllEmployeesInfo()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                string query = "SELECT * FROM Employee";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee employee = new Employee();
                                employee.EmployeeId = (int)reader["EmployeeId"];
                                employee.FirstName = (string)reader["FirstName"];
                                employee.LastName = (string)reader["LastName"];
                                employee.DateOfBirth = (DateTime)reader["DateOfBirth"];
                                employee.Gender = (string)reader["Gender"];
                                employee.Email = (string)reader["Email"];
                                employee.PhoneNumber = (string)reader["PhoneNumber"];
                                employee.Address = (string)reader["Address"];
                                employee.Position = (string)reader["Position"];
                                employee.JoiningDate = (DateTime)reader["JoiningDate"];
                                // Check if TerminationDate is DBNull
                                if (reader["TerminationDate"] != DBNull.Value)
                                {
                                    employee.TerminationDate = (DateTime)reader["TerminationDate"];
                                }
                                else
                                {
                                    employee.TerminationDate = null;
                                }
                                employees.Add(employee);
                            }
                        }
                    }
                }
                Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-7} {5,-17} {6,-12} {7,-17} {8,-12} {9,-12} {10,-15}",
               "EmployeeID", "First Name", "Last Name", "DOB", "Gender", "Email", "Phone", "Address", "Position", "Joining Date", "TerminationDate");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

        public void GetEmployeeInfoById(int employeeId)
        {
            try
            {
                Employee employee = null;
                string query = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee();
                                employee.EmployeeId = (int)reader["EmployeeId"];
                                employee.FirstName = (string)reader["FirstName"];
                                employee.LastName = (string)reader["LastName"];
                                employee.DateOfBirth = (DateTime)reader["DateOfBirth"];
                                employee.Gender = (string)reader["Gender"];
                                employee.Email = (string)reader["Email"];
                                employee.PhoneNumber = (string)reader["PhoneNumber"];
                                employee.Address = (string)reader["Address"];
                                employee.Position = (string)reader["Position"];
                                employee.JoiningDate = (DateTime)reader["JoiningDate"];
                                // Check if TerminationDate is DBNull
                                if (reader["TerminationDate"] != DBNull.Value)
                                {
                                    employee.TerminationDate = (DateTime)reader["TerminationDate"];
                                }
                                else
                                {
                                    employee.TerminationDate = null;
                                }
                            }
                        }
                    }
                }

                if (employee != null)
                {
                    Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-7} {5,-17} {6,-12} {7,-17} {8,-12} {9,-12} {10,-15}",
                        "EmployeeID", "First Name", "Last Name", "DOB", "Gender", "Email", "Phone", "Address", "Position", "Joining Date", "TerminationDate");
                    Console.WriteLine(employee);
                }
                else
                {
                    Console.WriteLine($"Employee ID {employeeId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

        public void AddEmployeeInfo(Employee employeeData)
        {

            string query = @"INSERT INTO Employee (FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, Position, JoiningDate, TerminationDate) 
                         VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Email, @PhoneNumber, @Address, @Position, @JoiningDate, @TerminationDate)";

            using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@FirstName", employeeData.FirstName);
                    command.Parameters.AddWithValue("@LastName", employeeData.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", employeeData.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", employeeData.Gender);
                    command.Parameters.AddWithValue("@Email", employeeData.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeData.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employeeData.Address);
                    command.Parameters.AddWithValue("@Position", employeeData.Position);
                    command.Parameters.AddWithValue("@JoiningDate", employeeData.JoiningDate);
                    command.Parameters.AddWithValue("@TerminationDate", employeeData.TerminationDate ?? (object)DBNull.Value);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Employee {employeeData.FirstName} information added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add employee information.");
                    }
                }
            }


        }

        public void UpdateEmployeeInfo(Employee employeeData)
        {
            try
            {
                string query = @"UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, 
                        Gender = @Gender, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address, 
                        Position = @Position, JoiningDate = @JoiningDate, TerminationDate = @TerminationDate
                        WHERE EmployeeId = @EmployeeId";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@EmployeeId", employeeData.EmployeeId);
                        command.Parameters.AddWithValue("@FirstName", employeeData.FirstName);
                        command.Parameters.AddWithValue("@LastName", employeeData.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", employeeData.DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", employeeData.Gender);
                        command.Parameters.AddWithValue("@Email", employeeData.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", employeeData.PhoneNumber);
                        command.Parameters.AddWithValue("@Address", employeeData.Address);
                        command.Parameters.AddWithValue("@Position", employeeData.Position);
                        command.Parameters.AddWithValue("@JoiningDate", employeeData.JoiningDate);
                        command.Parameters.AddWithValue("@TerminationDate", employeeData.TerminationDate ?? (object)DBNull.Value);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Employee with ID {employeeData.FirstName} has been successfully updated.");
                        }
                        else
                        {
                            Console.WriteLine($"Employee ID :  {employeeData.EmployeeId} not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

        public void RemoveEmployeeInfo(int employeeId)
        {
            try
            {
                string query = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";

                using (SqlConnection connection = new SqlConnection(DBConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Employee with ID {employeeId} has been successfully removed.");
                        }
                        else
                        {
                            Console.WriteLine($"Employee Id : {employeeId} Not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }
    }
}
