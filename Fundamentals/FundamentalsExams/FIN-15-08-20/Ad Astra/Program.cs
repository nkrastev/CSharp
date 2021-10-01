using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();
            Regex regex = new Regex(@"(#|\|)([A-Za-z ]+)(\1)([0-9]{2}\/[0-9]{2}\/[0-9]{2})(\1)(([1-9]|[1-8][0-9]|9[0-9]|[1-8][0-9]{2}|9[0-8][0-9]|99[0-9]|[1-8][0-9]{3}|9[0-8][0-9]{2}|99[0-8][0-9]|999[0-9]))(\1)");
            MatchCollection matches = regex.Matches(text);
            int totalCalories = 0;

            foreach (Match item in matches)
            {
                totalCalories += int.Parse(item.Groups[7].Value);
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups[2].Value}, Best before: {item.Groups[4].Value}, Nutrition: {item.Groups[7].Value}");

            }
        }
    }
}
