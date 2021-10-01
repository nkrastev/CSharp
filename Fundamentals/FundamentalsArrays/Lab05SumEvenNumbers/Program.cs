using System;

namespace Lab05SumEvenNumbers
{
    class Program
    {
        static void Main()
        {
            string values = Console.ReadLine();
            string[] items = values.Split();
            int[] arr = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
                arr[i] = int.Parse(items[i]);

            int result=CheckAndSum(arr);
            Console.WriteLine(result);

        }

        static int CheckAndSum(int [] newNameOfArray)
        {
            int sum = 0;
            foreach (var itemElement in newNameOfArray)
            {
                if (itemElement % 2 == 0) { sum += itemElement; }
            }
            return sum;
        }

    }
}
