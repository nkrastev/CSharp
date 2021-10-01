using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloFrance
{
    class Program
    {
        static void Main()
        {
            List<string> items = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<double> boughtItems = new List<double>();
            double budget = double.Parse(Console.ReadLine());

            for (int i = 0; i < items.Count; i++)
            {
                string[] itemValues = items[i].Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string product = itemValues[0];
                double price = double.Parse(itemValues[1]);

                if (product== "Clothes" && price<=50 && budget>=price)
                {                    
                    boughtItems.Add(price);
                    budget -= price;

                }
                if (product == "Shoes" && price <= 35 && budget >= price)
                {
                    boughtItems.Add(price);
                    budget -= price;
                }
                if (product == "Accessories" && price <= 20.5 && budget >= price)
                {
                    boughtItems.Add(price);
                    budget -= price;
                }
            }

            List<double> sellingItems = new List<double>();

            for (int i = 0; i < boughtItems.Count; i++)
            {
                sellingItems.Add(boughtItems[i] +boughtItems[i]* 0.4);                
            }

            double totalBought = boughtItems.Sum();
            double sellItems = sellingItems.Sum();

            double profit = sellItems - totalBought;

            
            foreach (var item in sellingItems)
            {
                Console.Write($"{item:f2} ");
            }

            if (sellingItems.Count>=1)
            {
                Console.WriteLine();
            }
            
            Console.WriteLine($"Profit: {profit:f2}");

            double total = budget + sellItems;

            if (total>=150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
