using System;
using System.Linq;

namespace MEx07MaxSequenceofEqualElements
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int finds = 0;
            int longest = 0;
            int elementItems = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                finds = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i]==arr[j])
                    {
                        finds++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (longest<finds)
                {
                    longest = finds;
                    elementItems = arr[i];
                    
                }
            }

            //Console.WriteLine($"{longest} element item> {elementItems}");
            for (int k = 1; k <=longest; k++)
            {
                Console.Write($"{elementItems} ");
            }
        }
    }
}
