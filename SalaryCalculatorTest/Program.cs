using Microsoft.Extensions.DependencyInjection;
using SalaryCalculatorTest.Factory;
using SalaryCalculatorTest.Model;
using System;
using System.Globalization;

namespace SalaryCalculatorTest
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main()
        {
            RegisterServices();

            var serviceApplication = _serviceProvider.GetRequiredService<ISalaryServiceApplication>();

            EmployeeSalaryRequest employeeSalaryRequest = new EmployeeSalaryRequest
            {
                HourlyRate = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture),
                HoursWorked = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture),
                EmployeeLocation = Console.ReadLine()
            };

            try
            {
                serviceApplication.PrintSalaryInformation(employeeSalaryRequest);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            DisposeServices();
        }

        private static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ISalaryServiceApplication, SalaryServiceApplication>()
                .AddSingleton<ISalaryCalculatorFactory, SalaryCalculatorFactory>()
                .AddSingleton<ISalaryReport, SalaryReport>()
                .BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null) return;

            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }

        }
    }
}
