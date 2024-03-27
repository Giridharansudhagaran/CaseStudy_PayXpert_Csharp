using PayXpert.Models;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Exceptions
{
    internal class PayrollGenerationException : Exception
    {
        public PayrollGenerationException(string message) : base(message) 
        {

        }   

    }
}
