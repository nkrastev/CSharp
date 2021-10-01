using System;
using System.Collections.Generic;
using System.Linq;

namespace SeizetheFire
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split("#", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> validCells = new List<int>();
            int water = int.Parse(Console.ReadLine());
            int fire = 0;

            for (int i = 0; i < input.Count; i++)
            {
                //High = 81 - 125
                //Medium 51 - 80
                //Low 1 - 50
                string[] cell = input[i].Split(" = ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string fireType = cell[0];
                int firePower = int.Parse(cell[1]);

                if (fireType == "High")
                {
                    if (firePower>=81 && firePower<=125 && water>=firePower)
                    {
                        water -= firePower;
                        fire += firePower;
                        validCells.Add(firePower);
                    }                              
                }
                if (fireType == "Medium")
                {
                    if (firePower >= 51 && firePower <= 80 && water >= firePower)
                    {
                        water -= firePower;
                        fire += firePower;
                        validCells.Add(firePower);
                    }                   
                }
                if (fireType == "Low")
                {
                    if (firePower >= 1 && firePower <= 50 && water >= firePower)
                    {
                        water -= firePower;
                        fire += firePower;
                        validCells.Add(firePower);
                    }                    
                }
            }

            Console.WriteLine("Cells:");
            foreach (var item in validCells)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine($"Effort: {fire*1.0/4:f2}");
            Console.WriteLine($"Total Fire: {fire}");


        }
    }
}
