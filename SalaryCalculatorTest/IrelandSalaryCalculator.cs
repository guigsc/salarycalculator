using SalaryCalculatorTest.Model;
using System.Collections.Generic;

namespace SalaryCalculatorTest
{
    public class IrelandSalaryCalculator : SalaryCalculator, ISalaryCalculator
    {
        protected override List<Deduction> GetDeductions(double grossAmount)
        {
            List<Deduction> deductions = new List<Deduction>
            {
                new Deduction { Name = "Income tax", Value = IncomeTax(grossAmount) },
                new Deduction { Name = "Universal Social Charge", Value = UniversalSocialCharge(grossAmount) },
                new Deduction { Name = "Pension", Value = Pension(grossAmount) }
            };

            return deductions;
        }

        private double IncomeTax(double grossAmount)
        {
            double incomeTax;

            if (grossAmount <= 600)
            {
                incomeTax = 0.25;
            }
            else
            {
                incomeTax = 0.4;
            }

            return grossAmount * incomeTax;
        }

        private double UniversalSocialCharge(double grossAmount)
        {
            double universalSocialCharge;

            if (grossAmount <= 500)
            {
                universalSocialCharge = 0.07;
            }
            else
            {
                universalSocialCharge = 0.08;
            }

            return grossAmount * universalSocialCharge;
        }

        private double Pension(double grossAmount)
        {
            return grossAmount * 0.04;
        }
    }
}
