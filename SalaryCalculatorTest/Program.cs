using SalaryCalculatorTest.Factory;
using SalaryCalculatorTest.Model;
using System;

namespace SalaryCalculatorTest
{
    class Program
    {
        static void Main()
        {
            EmployeeSalaryRequest employeeSalaryRequest = new EmployeeSalaryRequest
            {
                HourlyRate = Convert.ToDouble(Console.ReadLine()),
                HoursWorked = Convert.ToDouble(Console.ReadLine()),
                EmployeeLocation = Console.ReadLine()
            };

            SalaryService salaryService = new SalaryService(
                new SalaryCalculatorFactory(), 
                new SalaryReport()
            );

            salaryService.PrintSalaryInformation(employeeSalaryRequest); 
        }
    }
}
