using System;
using System.Collections.Generic;
using System.Linq;

namespace _1CompanyRoster
{
    class Program
    {
        static void Main()
        {
            List<Employee> listEmployees = new List<Employee>();
            List<Department> listDepartments = new List<Department>();

            ReadEmployees(listEmployees);

            GetUniqueDepartments(listEmployees, listDepartments);

            GetAverageSalaries(listEmployees, listDepartments);

            listDepartments = listDepartments.OrderByDescending(x => x.AverageSalary).ToList();

            listEmployees = listEmployees.OrderByDescending(x => x.Salary).ToList();

            //outpu the top record in list department is with the best average
            Console.WriteLine($"Highest Average Salary: {listDepartments[0].Name}");

            foreach (Employee item in listEmployees)
            {
                if (item.Department == listDepartments[0].Name)
                {
                    Console.WriteLine($"{item.Name} {item.Salary:f2}");
                }
            }
        }

        static List<Department> GetAverageSalaries(List<Employee> listEmployees, List<Department> listDepartments)
        {
            foreach (Department depitem in listDepartments)
            {
                string currentDepartment = depitem.Name;
                foreach (Employee empItem in listEmployees)
                {
                    if (empItem.Department == currentDepartment)
                    {
                        depitem.TotalCount++;
                        depitem.TotalSalaries += empItem.Salary;
                    }
                }
                depitem.AverageSalary = depitem.TotalSalaries / depitem.TotalCount;
            }
            return listDepartments;
        }

        static List<Department> GetUniqueDepartments(List<Employee> listEmployees, List<Department> listDepartments)
        {
            //copy unique departments in the new object list
            foreach (Employee item in listEmployees)
            {
                //new department instance
                Department newDept = new Department(item.Department, 0, 0, 0);
                bool departmentExist = false;
                foreach (Department depItem in listDepartments)
                {
                    if (depItem.Name == item.Department)
                    {
                        departmentExist = true;
                        break;
                    }
                }
                if (departmentExist == false)
                {
                    listDepartments.Add(newDept);
                }
            }
            return listDepartments;
        }

        static List<Employee> ReadEmployees(List<Employee> list)
        {
            int numberEmployees = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberEmployees; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string emplName = input[0];
                double emplSalary = double.Parse(input[1]);
                string emplDept = input[2];

                Employee newEmployee = new Employee(emplName, emplSalary, emplDept);
                list.Add(newEmployee);
            }
            return list;
        }
    }
    class Department
    {
        public Department(string name, double totalSalaries, int count, double avgSalary)
        {
            Name = name;
            TotalSalaries = totalSalaries;
            TotalCount = count;
            AverageSalary = avgSalary;
        }
        public string Name { get; set; }
        public double TotalSalaries { get; set; }
        public int TotalCount { get; set; }
        public double AverageSalary { get; set; }
    }

    class Employee
    {
        //constructor
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        //properties
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

    }
}
