using System;
using System.Linq;

namespace MEx03ZigZagArrays
{
    class Program
    {
        static void Main()
        {
            int numberOfArraysForRead = int.Parse(Console.ReadLine());
            int[] arr1 = new int[numberOfArraysForRead];
            int[] arr2 = new int[numberOfArraysForRead];

            for (int i = 0; i < numberOfArraysForRead; i++)
            {
                int[] currentArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2==0)
                {
                    arr1[i] = currentArray[0];
                    arr2[i] = currentArray[1];
                }
                else
                {
                    arr1[i] = currentArray[1];
                    arr2[i] = currentArray[0];
                }
            }
            foreach (var item in arr1)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            foreach (var item in arr2)
            {
                Console.Write(item + " ");
            }
        }
    }
}
