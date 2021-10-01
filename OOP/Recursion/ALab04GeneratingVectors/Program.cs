using System;

namespace ALab04GeneratingVectors
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            var index = 0;
            Generate(arr, index);
        }

        private static void Generate(int[] vector, int index)
        {
            if (index>vector.Length-1)
            {
                Console.WriteLine(String.Join("",vector));
                return;
            }

            for (int i = 0; i <=1; i++)
            {
                vector[index] = i;
                Generate(vector, index + 1);
            }
        }
    }
}
