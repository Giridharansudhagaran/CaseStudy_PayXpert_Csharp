using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Repository;
using PayXpert.Exceptions;
using PayXpert.Models;

namespace PayXpertTestUnit
{
    internal class InvalidInputTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VerifyErrorHandlingForInvalidEmployeeData()
        {
            // Arrange: Prepare invalid employee data
            string invalidFirstName = "";
            string invalidLastName = "";
            DateTime invalidDateOfBirth = new DateTime(2025, 1, 1);
            string invalidGender = "InvalidGender";
            string invalidEmail = "analisegmail.com";
            string invalidPhoneNumber = "123";
            string invalidAddress = "";
            string invalidPosition = "";
            DateTime invalidJoiningDate = DateTime.Now.AddDays(1);
            DateTime? invalidTerminationDate = DateTime.Now;

            Employee employee = new Employee(invalidFirstName, invalidLastName, invalidDateOfBirth,
                    invalidGender, invalidEmail, invalidPhoneNumber, invalidAddress, invalidPosition,
                    invalidJoiningDate, invalidTerminationDate);


            Assert.Throws<InvalidInputException>(
                   () => InvalidInputException.InvalidInput(employee)
             );
        }
    }
}
