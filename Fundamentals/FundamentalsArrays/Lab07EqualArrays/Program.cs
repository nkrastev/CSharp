using System;
using System.Linq;

namespace Lab07EqualArrays
{
    class Program
    {
        static void Main()
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isEqual = false;
            int sumOfElements = 0;
            int differenceIndex = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i]==arr2[i])
                {
                    sumOfElements += arr1[i];
                    isEqual = true;
                }
                else
                {
                    isEqual = false;
                    differenceIndex = i;
                    break;
                }
            }

            if (isEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfElements}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {differenceIndex} index");
            }

        }
    }
}
