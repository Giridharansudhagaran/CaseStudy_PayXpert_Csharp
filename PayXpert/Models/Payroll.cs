using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Models
{
    internal class Payroll
    {
        // Private fields
        private int payrollId;
        private int employeeId;
        private DateTime payPeriodStartDate;
        private DateTime payPeriodEndDate;
        private decimal basicSalary;
        private decimal overtimePay;
        private decimal deductions;
        private decimal netSalary;

        // Default constructor
        public Payroll()
        {
        }

        // Parametrized constructor
        public Payroll(int employeeID, DateTime payPeriodStartDate, DateTime payPeriodEndDate,
                        decimal basicSalary, decimal overtimePay, decimal deductions, decimal netSalary)
        {
            this.EmployeeId = employeeID;
            this.PayPeriodStartDate = payPeriodStartDate;
            this.PayPeriodEndDate = payPeriodEndDate;
            this.BasicSalary = basicSalary;
            this.OvertimePay = overtimePay;
            this.Deductions = deductions;
            this.NetSalary = netSalary;
        }

        // Properties with getters and setters
        public int PayrollId
        {
            get { return payrollId; }
            set { payrollId = value; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public DateTime PayPeriodStartDate
        {
            get { return payPeriodStartDate; }
            set { payPeriodStartDate = value; }
        }

        public DateTime PayPeriodEndDate
        {
            get { return payPeriodEndDate; }
            set { payPeriodEndDate = value; }
        }

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }

        public decimal OvertimePay
        {
            get { return overtimePay; }
            set { overtimePay = value; }
        }

        public decimal Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        public decimal NetSalary
        {
            get { return netSalary; }
            set { netSalary = value; }
        }

        public override string ToString()
        {
            return $"{PayrollId,-12} {EmployeeId,-12} {PayPeriodStartDate,-12:MM/dd/yyyy} {PayPeriodEndDate,-12:MM/dd/yyyy} {BasicSalary,-12} {OvertimePay,-12} {Deductions,-12} {NetSalary,-12}";
        }
    }
}
