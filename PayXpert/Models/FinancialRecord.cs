using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Models
{
    internal class FinancialRecord
    {
        // Private fields
        private int recordID;
        private int employeeId;
        private DateTime recordDate;
        private string description;
        private decimal amount;
        private string recordType;

        // Default constructor
        public FinancialRecord()
        {
        }

        // Parametrized constructor
        public FinancialRecord(int employeeID, DateTime recordDate, string description, decimal amount, string recordType)
        {
            this.EmployeeId = employeeID;
            this.RecordDate = recordDate;
            this.Description = description;
            this.Amount = amount;
            this.RecordType = recordType;
        }

        // Properties with getters and setters
        public int RecordID
        {
            get { return recordID; }
            set { recordID = value; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public DateTime RecordDate
        {
            get { return recordDate; }
            set { recordDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }

        public override string ToString()
        {
            return $"{RecordID,-12} {EmployeeId,-12} {RecordDate,-12:MM/dd/yyyy} {Description,-20} {Amount,-12} {RecordType,-12}";
        }
    }
}
