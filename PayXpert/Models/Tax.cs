using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Models
{
    internal class Tax
    {
        // Private fields
        private int taxID;
        private int employeeID;
        private int taxYear;
        private decimal taxableIncome;
        private decimal taxAmount;

        // Default constructor
        public Tax()
        {
        }

        // Parametrized constructor
        public Tax(int employeeID, int taxYear, decimal taxableIncome, decimal taxAmount)
        {
            this.EmployeeID = employeeID;
            this.TaxYear = taxYear;
            this.TaxableIncome = taxableIncome;
            this.TaxAmount = taxAmount;
        }

        // Properties with getters and setters
        public int TaxID
        {
            get { return taxID; }
            set { taxID = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public int TaxYear
        {
            get { return taxYear; }
            set { taxYear = value; }
        }

        public decimal TaxableIncome
        {
            get { return taxableIncome; }
            set { taxableIncome = value; }
        }

        public decimal TaxAmount
        {
            get { return taxAmount; }
            set { taxAmount = value; }
        }

        public override string ToString()
        {
            return $"{TaxID,-12} {EmployeeID,-12} {TaxYear,-12} {TaxableIncome,-12} {TaxAmount,-12}";
        }
    }
}
