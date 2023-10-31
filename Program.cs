using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }

        public Employee(string fullName, string position, double salary, string email)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            Email = email;
        }
    }

    public class EmployeeManagementSystem
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(string name)
        {
            Employee employeeToRemove = employees.FirstOrDefault(e => e.FullName == name);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
            }
        }

        public void UpdateEmployee(string email, string fullName, string position, double salary)
        {
            Employee employeeToUpdate = employees.FirstOrDefault(e => e.Email == email);

            if (employeeToUpdate != null)
            {
                employeeToUpdate.FullName = fullName;
                employeeToUpdate.Position = position;
                employeeToUpdate.Salary = salary;
            }
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            return employees
                .Where(e => e.FullName.ToLower().Contains(searchTerm) || e.Position.ToLower().Contains(searchTerm) || e.Email.ToLower().Contains(searchTerm))
                .ToList();
        }

        public void SortEmployeesByFullName()
        {
            employees = employees.OrderBy(e => e.FullName).ToList();
        }

        public void SortEmployeesBySalary()
        {
            employees = employees.OrderBy(e => e.Salary).ToList();
        }

        public void DisplayEmployees()
        {
            Console.WriteLine("Employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Full Name: {employee.FullName}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManagementSystem system = new EmployeeManagementSystem();

            Employee employee1 = new Employee("qwe", "asd", 4444, "qwe@gmail");
            Employee employee2 = new Employee("zxc", "vbn", 333, "zxc@gmail");

            system.AddEmployee(employee1);
            system.AddEmployee(employee2);

            system.DisplayEmployees();

            Console.WriteLine("\nSearch employee 1: ");
            var searchResults = system.SearchEmployees("qwe");
            system.DisplayEmployees();

            system.SortEmployeesBySalary();
            Console.WriteLine("\nSort by salary: ");
            system.DisplayEmployees();

            Console.WriteLine("\nRemove employee 1: ");
            system.RemoveEmployee("qwe");
            system.DisplayEmployees();
        }
    }
}
