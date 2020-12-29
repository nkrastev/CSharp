using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex09ListOfPredicates
{
    class Program
    {
        static void Main()
        {
            var endRange = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var result = new List<int>();

            for (int i = 1; i <= endRange; i++)
            {
                bool isNumberOk = true;
                for (int j = 0; j < input.Length; j++)
                {
                    if (i % input[j]==0)
                    {
                        isNumberOk = true;
                    }
                    else
                    {
                        isNumberOk = false;
                        break;
                    }
                }
                if (isNumberOk)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ",result));
        }
    }
}
