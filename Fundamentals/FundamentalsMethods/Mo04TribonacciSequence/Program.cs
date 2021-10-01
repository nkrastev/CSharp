using System;

namespace Mo04TribonacciSequence
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                Console.WriteLine(1);
            }
            else if (num == 2)
            {
                Console.WriteLine("1 1");
            }
            else
            {

                int[] arr = new int[num];

                arr[0] = 1;
                arr[1] = 1;
                arr[2] = 2;

                for (int i = 3; i < num; i++)
                {
                    arr[i] = arr[i - 1] + arr[i - 2] + arr[i - 3];
                }

                foreach (var item in arr)
                {
                    Console.Write(item+" ");
                }
            }
        }
    }
}
