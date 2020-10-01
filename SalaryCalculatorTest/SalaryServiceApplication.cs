using SalaryCalculatorTest.Factory;
using SalaryCalculatorTest.Model;

namespace SalaryCalculatorTest
{
    public interface ISalaryServiceApplication
    {
        void PrintSalaryInformation(EmployeeSalaryRequest employeeSalaryRequest);
    }

    public class SalaryServiceApplication : ISalaryServiceApplication
    {
        private readonly ISalaryCalculatorFactory salaryCalculatorFactory;
        private readonly ISalaryReport salaryReport;

        public SalaryServiceApplication(ISalaryCalculatorFactory salaryCalculatorFactory, ISalaryReport salaryReport)
        {
            this.salaryCalculatorFactory = salaryCalculatorFactory;
            this.salaryReport = salaryReport;
        }

        public void PrintSalaryInformation(EmployeeSalaryRequest employeeSalaryRequest)
        {
            ISalaryCalculator salaryCalculator = salaryCalculatorFactory.GetSalaryCalculator(employeeSalaryRequest.EmployeeLocation);
            Salary salary = salaryCalculator.CalculateSalary(employeeSalaryRequest.HourlyRate, employeeSalaryRequest.HoursWorked);
            salaryReport.Print(salary, employeeSalaryRequest.EmployeeLocation);
        }
    }
}
