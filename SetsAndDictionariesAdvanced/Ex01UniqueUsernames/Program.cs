using System;
using System.Collections.Generic;

namespace Ex01UniqueUsernames
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                usernames.Add(Console.ReadLine());
            }
            Console.WriteLine(String.Join("\n",usernames));
        }
    }
}
