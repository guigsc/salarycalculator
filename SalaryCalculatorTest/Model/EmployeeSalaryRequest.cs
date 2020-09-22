using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculatorTest.Model
{
    public class EmployeeSalaryRequest
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public string EmployeeLocation { get; set; }
    }
}
