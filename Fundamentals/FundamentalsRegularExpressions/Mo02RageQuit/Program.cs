using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            // group 1 is the string, group 2 is the number
            Regex regex = new Regex(@"([^0-9]+)(\d+)");
            MatchCollection matches = regex.Matches(input);
            
            StringBuilder result = new StringBuilder();
            List<char> uniqueList = new List<char>();

            foreach (Match item in matches)
            {
                //item is the combination of string and digit
                string itemString = item.Groups[1].Value;
                int itemNumber = int.Parse(item.Groups[2].Value);
                //get uppercase
                itemString = itemString.ToUpper();
                //get repeting string
                for (int j = 0; j < itemNumber; j++)
                {
                    //add to result
                    result.Append(itemString);                    
                }                
            }            
            Console.WriteLine($"Unique symbols used: {result.ToString().Distinct().Count()}");
            Console.WriteLine(result.ToString());
        }
    }
}
