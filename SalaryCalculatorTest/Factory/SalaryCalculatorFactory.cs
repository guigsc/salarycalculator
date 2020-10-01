using SalaryCalculatorTest.Decorators;
using System;
using System.Linq;

namespace SalaryCalculatorTest.Factory
{
    public class SalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        public ISalaryCalculator GetSalaryCalculator(string employeeLocation)
        {
            if (string.IsNullOrEmpty(employeeLocation))
            {
                string message = "Employee location can not be null or empty";
                throw new NotSupportedException(message);
            }

            var types = typeof(ISalaryCalculator).Assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(ISalaryCalculator).IsAssignableFrom(type))
                .ToList();

            ISalaryCalculator salaryCalculator = null;
            
            foreach(var type in types)
            {
                object[] customAttributes = type.GetCustomAttributes(typeof(EmployeeLocationAttribute), false);
                EmployeeLocationAttribute attribute = (EmployeeLocationAttribute)customAttributes.FirstOrDefault();

                if (attribute != null && attribute.Location == employeeLocation.ToUpperInvariant())
                {
                    salaryCalculator = Activator.CreateInstance(type) as ISalaryCalculator;
                    break;
                }
            }

            if (salaryCalculator == null)
            {
                string message = $"Could not find a salary calculator for employee location: '{employeeLocation}'";
                throw new NotSupportedException(message);
            }

            return salaryCalculator;
        }
    }
}
