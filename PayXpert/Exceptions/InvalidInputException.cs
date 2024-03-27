using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Models;

namespace PayXpert.Exceptions
{
    public class InvalidInputException:Exception
    {
        public InvalidInputException(string message) : base(message) 
        {
            
        }    

        public static void InvalidInput(Employee employee)
        {
            if (employee.DateOfBirth > DateTime.Now)
            {
                throw new InvalidInputException("Invalid date of birth!!!");
            }
            if (!employee.Email.Contains('@'))
            {
                throw new InvalidInputException("Invalid email address!!!");
            }
        }
    }
}
