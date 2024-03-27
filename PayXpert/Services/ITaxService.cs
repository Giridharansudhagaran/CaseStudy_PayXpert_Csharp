using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Services
{
    public interface ITaxService
    {
        void CalculateTax(int employeeId, int taxYear);
        void GetTaxById(int taxId);
        void GetTaxesForEmployee(int employeeID);
        void GetTaxesForYear(int taxYear);
    }
}
