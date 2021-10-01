using System;
using System.IO;

namespace ALab01OddLines
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("Input.txt");
            for (int i = 0; i < input.Length; i++)
            {
                if (i% 2!=0)
                {
                    Console.WriteLine(input[i]);
                }
            }
        }
    }
}
