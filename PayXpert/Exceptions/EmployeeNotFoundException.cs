using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;

namespace PayXpert.Exceptions
{
    internal class EmployeeNotFoundException: Exception
    {
        public EmployeeNotFoundException(string message) : base(message)
        {

        }

    }
}
