using System;
using System.Linq;

namespace ALab03CountUppercaseWords
{
    class Program
    {
        static void Main()
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToList()
                .ForEach(Console.WriteLine);          
        }
    }
}
