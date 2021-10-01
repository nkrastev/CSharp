using System;

namespace Lab04ReverseArrayofStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] items = values.Split();
            string[] arr = new string[items.Length];

            for (int i = 0; i < items.Length; i++)
                arr[i] = items[i];

            Array.Reverse(arr);

            PrintReversedArray(arr);
        }

        static void PrintReversedArray(string[] newArrayInMethod)
        {
            foreach (var element in newArrayInMethod)
            {
                Console.Write(element + " ");
            }
        }
    }
}
