using System;
using System.Linq;

namespace MEx06EqualSums
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false; 

            for (int i = 0; i <= arr.Length-1; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                // current element is arr[i]

                //left side
                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }
                //right side
                for (int k = i+1; k <= arr.Length - 1; k++)
                {
                    rightSum += arr[k];
                }

                if (leftSum==rightSum)
                {
                    Console.WriteLine(i);
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
