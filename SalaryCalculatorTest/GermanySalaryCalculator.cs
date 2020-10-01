using SalaryCalculatorTest.Decorators;
using SalaryCalculatorTest.Model;
using System.Collections.Generic;

namespace SalaryCalculatorTest
{
    [EmployeeLocation("GERMANY")]
    public class GermanySalaryCalculator : SalaryCalculator, ISalaryCalculator
    {
        protected override List<Deduction> GetDeductions(double grossAmount)
        {
            List<Deduction> deductions = new List<Deduction>
            {
                new Deduction { Name = "Income tax", Value = IncomeTax(grossAmount) },
                new Deduction { Name = "Pension", Value = Pension(grossAmount) }
            };

            return deductions;
        }

        private double IncomeTax(double grossAmount)
        {
            double incomeTax;

            if (grossAmount <= 400)
            {
                incomeTax = 0.25;
            }
            else
            {
                incomeTax = 0.32;
            }

            return grossAmount * incomeTax;
        }

        private double Pension(double grossAmount)
        {
            return grossAmount * 0.02;
        }
    }
}
