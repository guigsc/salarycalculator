using SalaryCalculatorTest.Model;
using System;

namespace SalaryCalculatorTest
{
    public interface ISalaryReport
    {
        void Print(Salary salary, string employeeLocation);
    }

    public class SalaryReport : ISalaryReport
    {
        public void Print(Salary salary, string employeeLocation)
        {
            if (salary == null) return;

            Console.WriteLine($"Employee location: {employeeLocation}" + Environment.NewLine);
            Console.WriteLine($"GrossAmount: ${salary.GrossAmount}" + Environment.NewLine);

            if (salary.Deductions.Count > 0) Console.WriteLine("Less deductions" + Environment.NewLine);

            foreach (var deduction in salary.Deductions)
                Console.WriteLine($"{deduction.Name}: ${deduction.Value}");

            Console.WriteLine($"Net Amount: ${salary.NetAmount}");
        }
    }
}
