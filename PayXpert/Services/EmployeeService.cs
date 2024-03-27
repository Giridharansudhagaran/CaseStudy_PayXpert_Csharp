using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Exceptions;
using PayXpert.Models;
using PayXpert.Repository;

namespace PayXpert.Services
{
    internal class EmployeeService:IEmployeeService
    {
        EmployeeRepository employeeRepository;

        public EmployeeService() 
        {
            employeeRepository = new EmployeeRepository();
        }

        public void AddEmployee(Employee employeeData)
        {
            employeeRepository.AddEmployeeInfo(employeeData);

        }

        public void GetAllEmployees()
        { 
             employeeRepository.GetAllEmployeesInfo();
        }

        public void GetEmployeeById(int employeeId)
        {
 
             employeeRepository.GetEmployeeInfoById(employeeId);
        }

        public void RemoveEmployee(int employeeId)
        {

             employeeRepository.RemoveEmployeeInfo(employeeId);
        }

        public void UpdateEmployee(Employee employeeData)
        {
             employeeRepository.UpdateEmployeeInfo(employeeData);

        }

        public void EmployeeMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Employee Details");
                Console.WriteLine("---------------------");
                Console.WriteLine($"1: Add Employee Record\n2: Update Employee By ID\n3: Remove Employee By ID\n4: Get Employee By ID\n5: Display Employee Records\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Employee employee = new Employee();
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter first name: ");
                            string fname = Console.ReadLine();
                            Console.WriteLine("Enter last name: ");
                            string lname = Console.ReadLine();
                            Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                            DateTime dob = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Gender: ");
                            string gender = Console.ReadLine();
                            Console.WriteLine("Enter email: ");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter phone number: ");
                            string phno = Console.ReadLine();
                            Console.WriteLine("Enter the address: ");
                            string address = Console.ReadLine();
                            Console.WriteLine("Enter the position: ");
                            string position = Console.ReadLine();
                            Console.WriteLine("Enter Joining Date (yyyy-mm-dd): ");
                            DateTime joiningdate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Termination Date (yyyy-mm-dd): ");
                            DateTime terminationdate = DateTime.Parse(Console.ReadLine());
                            employee = new Employee(fname, lname, dob, gender, email, phno, address, position, joiningdate, terminationdate);
                            InvalidInputException.InvalidInput(employee);
                            AddEmployee(employee);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Employee ID to be Updated");
                            int u_employeeId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter first name: ");
                            string u_fname = Console.ReadLine();
                            Console.WriteLine("Enter last name: ");
                            string u_lname = Console.ReadLine();
                            Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                            DateTime u_dob = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Gender: ");
                            string u_gender = Console.ReadLine();
                            Console.WriteLine("Enter email: ");
                            string u_email = Console.ReadLine();
                            Console.WriteLine("Enter phone number: ");
                            string u_phno = Console.ReadLine();
                            Console.WriteLine("Enter the address: ");
                            string u_address = Console.ReadLine();
                            Console.WriteLine("Enter the position: ");
                            string u_position = Console.ReadLine();
                            Console.WriteLine("Enter Joining Date (yyyy-mm-dd): ");
                            DateTime u_joiningdate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Termination Date (yyyy-mm-dd): ");
                            DateTime u_terminationdate = DateTime.Parse(Console.ReadLine());
                            employee = new Employee(u_employeeId,u_fname, u_lname, u_dob, u_gender, u_email, u_phno, u_address, u_position, u_joiningdate, u_terminationdate);
                            InvalidInputException.InvalidInput(employee);
                            UpdateEmployee(employee);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Enter Employee id to be removed: ");
                            int r_id = int.Parse(Console.ReadLine());
                            RemoveEmployee(r_id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Enter Employee id to be searched: ");
                            int g_id = int.Parse(Console.ReadLine());
                            GetEmployeeById(g_id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                    case 5:
                        GetAllEmployees();
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
