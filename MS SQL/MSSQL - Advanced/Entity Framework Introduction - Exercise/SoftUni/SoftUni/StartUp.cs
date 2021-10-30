using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            var db = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(db));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
            //Console.WriteLine(AddNewAddressToEmployee(db));
            //Console.WriteLine(GetEmployeesInPeriod(db));
            //Console.WriteLine(GetAddressesByTown(db));
            //Console.WriteLine(GetEmployee147(db));
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));
            //Console.WriteLine(GetLatestProjects(db));
            //Console.WriteLine(IncreaseSalaries(db));
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));
            //Console.WriteLine(DeleteProjectById(db));
            Console.WriteLine(RemoveTown(db));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb= new StringBuilder();

            var employees = context.Employees
                .Select(e => new {e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary})
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new { e.FirstName, e.Salary })
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Salary })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            context.Addresses.Add(address);

            var nakov = context.Employees
                .Where(e => e.LastName == "Nakov")
                .First();

            nakov.Address = address;

            context.SaveChanges();

            var sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new { e.Address.AddressId, e.Address.AddressText })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.AddressText}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => 
                    ep.Project.StartDate >= DateTime.Parse("Jan 1, 2001") &&
                    ep.Project.StartDate < DateTime.Parse("Jan 1, 2004")))
                .Select(ep => new
                {
                    ep.FirstName,
                    ep.LastName,
                    Manager = ep.Manager.FirstName + " " + ep.Manager.LastName,
                    Projects = ep.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                })
                .Take(10)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager}");
                
                foreach (var ep in employee.Projects)
                {
                    if (ep.EndDate == null)
                    {
                        sb.AppendLine($"--{ep.Name} - {ep.StartDate} - not finished");
                    }
                    else
                    {
                        sb.AppendLine($"--{ep.Name} - {ep.StartDate} - {ep.EndDate}");
                    }
                }
            }

            return sb.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.EmployeeCount} employees");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.Project.Name
                        })
                        .ToArray(),
                })
                .First();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    Manager = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToArray()
                })
                .ToArray();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} – {department.Manager}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString());
            }

            return sb.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => new [] {"Engineering", "Tool Design", "Marketing", "Information Services" }
                    .Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            //context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projectToRemove = context.Projects
                .Single(p => p.ProjectId == 2);

            var employeesProjectsToRemove = context.EmployeesProjects.Where(ep => ep.ProjectId == 2).ToList();

            foreach (var ep in employeesProjectsToRemove)
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.SaveChanges();

            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            context.Projects.Take(10).ToList().ForEach(p => sb.AppendLine(p.Name));

            return sb.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            

            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == "Seattle").ToList();

            foreach (var address in addressesToDelete)
            {
                var employees = context.Employees
                    .Where(e => e.AddressId == address.AddressId).ToList();

                foreach (var employee in employees)
                {
                    employee.AddressId = null;
                }
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(context.Towns.Single(t => t.Name == "Seattle"));

            context.SaveChanges();

            sb.AppendLine($"{addressesToDelete.Count} addresses in Seattle were deleted");

            return sb.ToString().Trim();
        }
    }
}
