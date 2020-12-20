using System;
using System.Linq;

namespace ALab05GeneratingCombinations
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var border = int.Parse(Console.ReadLine());
            var vector = new int[border];           

            GenerateCombs(arr, vector, 0,0);
        }

        private static void GenerateCombs(int[] set, int[] vector, int index, int border)
        {
            if (index==vector.Length)
            {
                Console.WriteLine(String.Join(" ",vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenerateCombs(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}
