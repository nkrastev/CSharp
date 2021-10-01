using System;
using System.Linq;

namespace MEx04ArrayRotation
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int operationsCount = int.Parse(Console.ReadLine());
            //int lastIndex = arr.Length-1;

            for (int i = 0; i < operationsCount; i++)
            {
                int vtoriElement = arr[1];
                // wtoria stava pyrwi, tretiq vtori i t.n. pyrviq stava posleden
                for (int j = 1; j < arr.Length-1; j++)
                {
                    arr[j] = arr[j+1];
                }
                int lastIndex = arr.Length - 1;
                int temp = arr[0];
                arr[lastIndex] = arr[0];
                arr[0] = vtoriElement;

            }

            foreach (var element in arr)
            {
                Console.Write(element+" ");
            }
        }
    }
}
