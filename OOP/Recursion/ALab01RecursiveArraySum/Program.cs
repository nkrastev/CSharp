using System;
using System.Linq;

namespace ALab01RecursiveArraySum
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var index =0;            
            Console.WriteLine(Sum(arr, index));
        }

        private static int Sum(int[] arr, int index)
        {
            if (index==arr.Length)
            {
                return 0;
            }

            return arr[index]+Sum(arr, index + 1);
        }
    }
}
