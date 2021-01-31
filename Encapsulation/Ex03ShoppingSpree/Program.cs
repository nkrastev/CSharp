using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                persons = Console.ReadLine().Split(';').ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Person(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                products = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Product(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                var person = persons.First(p => p.Name == tokens[0]);
                var product = products.First(p => p.Name == tokens[1]);

                Console.WriteLine(person.AddProduct(product));
            }

            persons.ForEach(p => Console.WriteLine(p));
        }
    }
}
