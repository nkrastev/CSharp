using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ex09CustomHashSet
{
    class Program
    {
        static void Main()
        {
            int size = 50000;
            CustomSet custom = new CustomSet();
            List<string> list = new List<string>();
            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < size; i++)
            {
                list.Add(i.ToString());
            }
            for (int i = 0; i < size; i++)
            {
                list.Contains(i.ToString());
            }
            watch.Stop();
            Console.WriteLine($"List time: {watch.Elapsed}");

            
            watch.Reset();
            watch.Start();
            for (int i = 0; i < size; i++)
            {
                custom.Add(i.ToString()+i.ToString());
            }
            for (int i = 0; i < size; i++)
            {
                custom.Contains(i.ToString());
            }
            watch.Stop();
            Console.WriteLine($"Custom hashset time: {watch.Elapsed}");



        }
    }
}
