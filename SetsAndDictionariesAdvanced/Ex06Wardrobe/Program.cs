using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06Wardrobe
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var wardrobe = ReadData(n);
            var filter = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var searchedColor = filter[0];
            var searchedCloth = filter[1];

            foreach (var item in wardrobe)
            {
                //Console.WriteLine($"{item.Key} clothes:");
                //for (int i = 0; i < item.Value.Count; i++)
                //{
                //    if (item.Key==searchedColor && item.Value[i]==searchedCloth)
                //    {
                //        Console.WriteLine($"* {item.Value[i]} - 1 (found!)");
                //    }
                //    else
                //    {
                //        Console.WriteLine($"* {item.Value[i]} - 1");
                //    }
                //}
            }
            
        }

        private static Dictionary<string, Dictionary<string, int>> ReadData(int n)
        {
            var data = new Dictionary<string, Dictionary<string,int>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var color = input[0];
                var items = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();


                
            }
            return data;            
        }
    }
}
