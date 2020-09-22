using SalaryCalculatorTest.Model;
using System.Collections.Generic;
using System.Linq;

namespace SalaryCalculatorTest
{
    public interface ISalaryCalculator
    {
        Salary CalculateSalary(double hourlyRate, double hoursWorked);
    }

    public abstract class SalaryCalculator : ISalaryCalculator
    {
        public virtual Salary CalculateSalary(double hourlyRate, double hoursWorked)
        {
            Salary salary = new Salary();

            salary.GrossAmount = GetGrossAmount(hourlyRate, hoursWorked);
            salary.Deductions.AddRange(GetDeductions(salary.GrossAmount));
            salary.NetAmount = GetNetAmount(salary.GrossAmount, salary.Deductions);

            return salary;
        }

        protected virtual double GetGrossAmount(double hourlyRate, double hoursWorked)
        {
            return hourlyRate * hoursWorked;
        }

        protected abstract List<Deduction> GetDeductions(double grossAmount);

        protected virtual double GetNetAmount(double grossAmount, List<Deduction> deductions)
        {
            return grossAmount - deductions.Sum(deduction => deduction.Value);
        }
    }
}
