using System.Collections.Generic;

namespace SalaryCalculatorTest.Model
{
    public class Salary
    {
        public Salary()
        {
            Deductions = new List<Deduction>();
        }

        public double GrossAmount { get; set; }
        public List<Deduction> Deductions { get; }
        public double NetAmount { get; set;  }
    }
}
