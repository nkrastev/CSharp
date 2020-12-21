using System;
using System.IO;

namespace ALab02LineNumbers
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("input.txt");
            File.Delete("output.txt");
            var counter = 1;
            for (int i = 0; i < input.Length; i++)
            {                
                File.AppendAllText("output.txt", $"{counter}. {input[i]}\n");
                counter++;              
            }
        }
    }
}
