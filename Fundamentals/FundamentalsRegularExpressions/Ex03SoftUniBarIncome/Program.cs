using System;
using System.Text.RegularExpressions;

namespace Ex03SoftUniBarIncome
{
    class Program
    {
        static void Main()
        {
            string order = Console.ReadLine();
            double income = 0;
            string pattern = @"%([A-Z][a-z]+)%(.*?)<(\w+)>(.*?)\|([0-9]+)\|(.*?)([0-9]+.?[0-9]*?)\$";
            Regex regex = new Regex(pattern);

            while (order!= "end of shift")
            {
                MatchCollection matches = regex.Matches(order);

                string customerName = "";
                string product = "";
                string strCount = "";
                string strPrice = "";

                foreach (Match item in matches)
                {
                    customerName = item.Groups[1].Value;
                    product = item.Groups[3].Value;
                    strCount = item.Groups[5].Value;
                    strPrice = item.Groups[7].Value;
                }

                if (customerName!="" && product!="" && strCount!="" && strPrice!="")
                {
                    //all matches are valid
                    int count = int.Parse(strCount);
                    double price = double.Parse(strPrice);
                    Console.WriteLine($"{customerName}: {product} - {count*price:f2}");

                    income += count * price;
                }

                order = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
