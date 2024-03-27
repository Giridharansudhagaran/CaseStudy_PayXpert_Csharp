using PayXpert.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Services
{
    public interface IPayrollService
    {
        void GeneratePayroll(int employeeId, DateTime startDate, DateTime endDate,decimal basicsalary,decimal deductions, decimal overtimepay);
        void GetPayrollById(int parollId);
        void GetPayrollsForEmployee(int employeeId);
        void GetPayrollsForPeriod(DateTime startDate, DateTime endDate);
    }
}
