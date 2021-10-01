using System;
using System.Collections.Generic;

namespace Ex02AMinerTask
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, double> dictionary = new Dictionary<string, double>();

            while (true)
            {
                string resource = Console.ReadLine();
                if (resource=="stop")
                {
                    break;
                }
                double quantity = double.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(resource))
                {
                    dictionary.Add(resource, quantity);
                }
                else
                {
                    dictionary[resource] += quantity;
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
