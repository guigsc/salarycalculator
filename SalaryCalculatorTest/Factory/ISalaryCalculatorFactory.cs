using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculatorTest.Factory
{
    public interface ISalaryCalculatorFactory
    {
        ISalaryCalculator GetSalaryCalculator(string employeeLocation);
    }
}
