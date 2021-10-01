using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08CompanyUsers
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> catalogCompanies = new Dictionary<string, List<string>>();
            string[] command = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (command[0]!="End")
            {
                string company = command[0];
                string employee = command[1];

                AddEmployeeToCompany(catalogCompanies, company, employee);

                command= Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }            

            //When you finish reading the data, order the companies by the name in ascending order. 
            catalogCompanies=catalogCompanies.OrderBy(x=>x.Key).ToDictionary(x => x.Key, x=>x.Value);

            //output
            foreach (var item in catalogCompanies)
            {
                Console.WriteLine(item.Key);
                foreach (var employees in item.Value)
                {
                    Console.WriteLine($"-- {employees}");
                }
            }            

        }

        private static Dictionary<string,List<string>> AddEmployeeToCompany
            (
            Dictionary<string, List<string>> catalogCompanies, 
            string company, 
            string employee
            )
        {
            if (catalogCompanies.ContainsKey(company))
            {
                //company exist, check for employee
                if (!catalogCompanies[company].Contains(employee))
                {
                    //employee doesnt exist in current company, add it
                    catalogCompanies[company].Add(employee);
                }
            }
            else
            {
                //no such company, add company, add list, add employee
                List<string> newListOfEmployees = new List<string>();
                newListOfEmployees.Add(employee);
                catalogCompanies.Add(company, newListOfEmployees);
            }
            
            return catalogCompanies;
        }
    }
}
