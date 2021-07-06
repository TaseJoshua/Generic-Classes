using System;
using TaseFood.StorageApp.Data;
using TaseFood.StorageApp.Entities;
using TaseFood.StorageApp.Repositories;

namespace TaseFood.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;
            AddEmployee(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);


            var organisationRepository = new ListRepository<Organisation>();
            AddOrganisation(organisationRepository);
            WriteAllToConsole(organisationRepository);



            Console.ReadLine();
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee e)
        {
            Console.WriteLine($"Employee added => {e.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var oluManager = new Manager { FirstName = "Olu" };
            var oluManagerCopy = oluManager.Copy();
            managerRepository.Add(oluManager);
            if (oluManagerCopy is not null)
            {
                oluManagerCopy.FirstName += "_Copy";
                managerRepository.Add(oluManagerCopy);
            }

            managerRepository.Add(new Manager { FirstName = "Jamie" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> Repository)
        {
            var items = Repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2 is {employee.FirstName}");
        }

        private static void AddEmployee(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Tase" },
                new Employee { FirstName = "Beni" },
                new Employee { FirstName = "Ola" }
            };
            employeeRepository.AddBatch(employees);

        }

        private static void AddOrganisation(IRepository<Organisation> organisationRepository)
        {
            var organisations = new[]
            {
                new Organisation { Name = "Cavali" },
                new Organisation { Name = "Nike" },
                new Organisation { Name = "Gucci" }
            };
            organisationRepository.AddBatch(organisations);
           
        }

       
    }
}
