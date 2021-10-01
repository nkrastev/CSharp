using System;
using System.Collections.Generic;

namespace ALab05RecordUniqueNames
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            HashSet<string> hashSet = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                hashSet.Add(input);
            }
            Console.WriteLine(String.Join("\n",hashSet));
        }
    }
}
