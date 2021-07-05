using System;
using TaseFood.StorageApp.Entities;
using TaseFood.StorageApp.Repositories;

namespace TaseFood.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            AddEmployee(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organisationRepository = new GenericRepository<Organisation>();
            AddOrganisation(organisationRepository);
            Console.ReadLine();
        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2 is {employee.FirstName}");
        }

        private static void AddEmployee(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Tase" });
            employeeRepository.Add(new Employee { FirstName = "Beni" });
            employeeRepository.Add(new Employee { FirstName = "Ola" });
            employeeRepository.Save();
        }

        private static void AddOrganisation(GenericRepository<Organisation> organisationRepository)
        {
            organisationRepository.Add(new Organisation { Name = "Tase" });
            organisationRepository.Add(new Organisation { Name = "Nike" });
            organisationRepository.Add(new Organisation { Name = "Gucci" });
            organisationRepository.Save();
        }
    }
}
