using SalaryCalculatorTest.Decorators;
using SalaryCalculatorTest.Model;
using System.Collections.Generic;

namespace SalaryCalculatorTest
{
    [EmployeeLocation("ITALY")]
    public class ItalySalaryCalculator : SalaryCalculator, ISalaryCalculator
    {
        protected override List<Deduction> GetDeductions(double grossAmount)
        {
            List<Deduction> deductions = new List<Deduction>
            {
                new Deduction { Name = "Income tax", Value = IncomeTax(grossAmount) },
                new Deduction { Name = "INPS", Value = INPS(grossAmount) }
            };

            return deductions;
        }

        private double IncomeTax(double grossAmount)
        {
            return grossAmount * 0.25;
        }

        private double INPS(double grossAmount)
        {
            return grossAmount * 0.0919;
        }
    }
}
