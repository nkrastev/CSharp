using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ex01Furniture
{
    class Program
    {
        static void Main()
        {
            List<string> furnitureList = new List<string>();
            double spendMoney = 0;            

            CalculateAndPrint(furnitureList, spendMoney);
            
        }

        private static void CalculateAndPrint(List<string> furnitureList, double spendMoney)
        {
            string pattern = @">>([A-z]*)<<([0-9]+.?[0-9]+?)!([0-9]+)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            while (input!= "Purchase")
            {
                MatchCollection matches = regex.Matches(input);

                foreach (Match item in matches)
                {
                    string product = item.Groups[1].Value;
                    double price = double.Parse(item.Groups[2].Value);
                    int quantity = int.Parse(item.Groups[3].Value);

                    furnitureList.Add(product);
                    spendMoney += price * quantity;

                }

                input = Console.ReadLine();
            }

            //output
            Console.WriteLine("Bought furniture:");
            if (furnitureList.Count>0)
            {
                Console.WriteLine(String.Join("\n", furnitureList));
            }            
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}
