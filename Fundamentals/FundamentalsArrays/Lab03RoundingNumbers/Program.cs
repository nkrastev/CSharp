using System;

namespace Lab03RoundingNumbers
{
    class Program
    {
        static void Main()
        {
            string values = Console.ReadLine();
            string[] items = values.Split(" ");
            double[] arr = new double[items.Length];
            for (int i = 0; i < items.Length; i++) 
                arr[i] = double.Parse(items[i]);

            PrintArray(arr);
        }

        static void PrintArray(double[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine($"{item} => {Math.Round(item, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
