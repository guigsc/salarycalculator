using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculatorTest.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class EmployeeLocationAttribute : Attribute
    {
        public string Location { get; set; }
        public EmployeeLocationAttribute(string location)
        {
            this.Location = location;
        }
    }
}
