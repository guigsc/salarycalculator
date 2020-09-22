using System;

namespace SalaryCalculatorTest.Factory
{
    public interface ISalaryCalculatorFactory
    {
        public SalaryCalculator GetSalaryCalculator(string employeeLocation);
    }

    public class SalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        public SalaryCalculator GetSalaryCalculator(string employeeLocation) 
        {
            return employeeLocation?.ToLower() switch
            {
                "ireland" => new IrelandSalaryCalculator(),
                "italy" => new ItalySalaryCalculator(),
                "germany" => new GermanySalaryCalculator(),
                _ => throw new Exception("Unknown location")
            }; 
        }
    }
}
