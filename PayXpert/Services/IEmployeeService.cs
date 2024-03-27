using PayXpert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Services
{
    public interface IEmployeeService
    {
        void GetEmployeeById(int employeeId);
        void GetAllEmployees();
        void AddEmployee(Employee employeeData);
        void UpdateEmployee(Employee employeeData);
        void RemoveEmployee(int employeeId);
    }
}
