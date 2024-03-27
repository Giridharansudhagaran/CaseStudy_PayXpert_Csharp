using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Models
{
    public class Employee
    {
        // Private fields
        private int employeeId;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string email;
        private string phoneNumber;
        private string address;
        private string position;
        private DateTime joiningDate;
        private DateTime? terminationDate;

        // Default constructor
        public Employee()
        {
        }

        // Parametrized constructor
        public Employee(string firstName, string lastName, DateTime dateOfBirth, string gender,
                        string email, string phoneNumber, string address, string position, DateTime joiningDate,
                        DateTime? terminationDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Position = position;
            this.JoiningDate = joiningDate;
            this.TerminationDate = terminationDate;
        }


        public Employee(int employeeID, string firstName, string lastName, DateTime dateOfBirth, string gender,
                       string email, string phoneNumber, string address, string position, DateTime joiningDate,
                       DateTime? terminationDate)
        {
            this.EmployeeId = employeeID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Position = position;
            this.JoiningDate = joiningDate;
            this.TerminationDate = terminationDate;
        }

        // Properties with getters and setters
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public DateTime JoiningDate
        {
            get { return joiningDate; }
            set { joiningDate = value; }
        }

        public DateTime? TerminationDate
        {
            get { return terminationDate; }
            set { terminationDate = value; }
        }

        public override string ToString()
        {
            return $"{EmployeeId,-12} {FirstName,-12} {LastName,-12} {DateOfBirth,-12:MM/dd/yyyy} {Gender,-7} {Email,-17} {PhoneNumber,-12} {Address,-17} {Position,-12} {JoiningDate,-12:MM/dd/yyyy} {TerminationDate ?? (object)"N/A",-15}";
        }

    }
}
