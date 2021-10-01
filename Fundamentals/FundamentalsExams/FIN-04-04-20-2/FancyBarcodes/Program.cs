using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                bool isValid = CheckValidBarcode(input);

                if (isValid)
                {
                    PrintProductGroup(input);
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }

        private static void PrintProductGroup(string input)
        {
            Regex regex = new Regex(@"[0-9]");
            MatchCollection matches = regex.Matches(input);
            string productCode = "";
            if (matches.Count > 0)
            {
                foreach (Match item in matches)
                {
                    productCode += item.Value;
                }
            }
            else
            {
                productCode = "00";
            }
            Console.WriteLine($"Product group: {productCode}");
        }

        private static bool CheckValidBarcode(string input)
        {
            bool isValid = false;
            Regex regex = new Regex(@"(@#{1,})([A-Z][A-Za-z0-9]{4,}[A-Z])(@#{1,})");
            MatchCollection matches = regex.Matches(input);
            string matchValueString = "";
            if (matches.Count == 1)
            {
                foreach (Match item in matches)
                {
                    matchValueString = item.Value;
                }
            }

            if (matchValueString == input)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
