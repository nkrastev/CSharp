using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04Orders
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, double> dictionaryPrices = new Dictionary<string, double>();
            Dictionary<string, int> dictionaryQuantity = new Dictionary<string, int>();

            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (input[0] != "buy")
            {
                string product = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (!dictionaryPrices.ContainsKey(product))
                {
                    //adding new product to both dicts
                    dictionaryPrices.Add(product, price);
                    dictionaryQuantity.Add(product, quantity);
                }
                else
                {
                    //product exist increase quantity, replace price
                    dictionaryPrices[product] = price;
                    dictionaryQuantity[product] += quantity;
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            foreach (var item in dictionaryQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value*dictionaryPrices[item.Key]:f2}");
            }

        }
    }
}
