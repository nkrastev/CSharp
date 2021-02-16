using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeaSalad
{
    class StartUp
    {
        static void Main()
        {
            Dictionary<string, int> vegetableCalories = new Dictionary<string, int>
            {
                { "tomato", 80},
                { "carrot", 136},
                { "lettuce", 109},
                { "potato", 215}
            };
            List<string> salads = new List<string>();

            var vegetables = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(v => vegetableCalories.ContainsKey(v)));
            
            var calories =   new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (vegetables.Count > 0 && calories.Count > 0)
            {
                int currentSalad = calories.Peek();
                while (currentSalad > 0 && vegetables.Count > 0)
                {
                    currentSalad -= vegetableCalories[vegetables.Dequeue()];
                }
                salads.Add(calories.Pop().ToString());                
            }

            Console.WriteLine(String.Join(" ",salads));

            if (vegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }

            if (calories.Count > 0)
            {
                Console.WriteLine(string.Join(" ", calories));
            }





        }
    }
}
