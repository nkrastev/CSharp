using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab03ProductShop
{
    class Program
    {
        static void Main()
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();
            var command = Console.ReadLine();
            while (command!= "Revision")
            {
                //lidl, juice, 2.30
                var cmdArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var store = cmdArgs[0];
                var product = cmdArgs[1];
                var price = double.Parse(cmdArgs[2]);

                if (shops.ContainsKey(store))
                {
                    shops[store].Add(product, price);
                }
                else
                {
                    shops.Add(store, new Dictionary<string, double>());
                    shops[store].Add(product, price);
                }
                command = Console.ReadLine();
            }

            shops=shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in shops)
            {
                Console.WriteLine(item.Key+ "->");
                foreach (var pr in item.Value)
                {
                    Console.WriteLine($"Product: {pr.Key}, Price: {pr.Value}");
                }
            }
        }
    }
}
