using System;

namespace MEx02CommonElements
{
    class Program
    {
        static void Main()
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[i]==arr1[j])
                    {
                        Console.Write(arr2[i]+" ");
                    }
                }
            }
            
            
        }
    }
}
