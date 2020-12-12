using System;
using System.Collections.Generic;

namespace ALab07SoftUniParty
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var regular = new HashSet<string>();
            var vip = new HashSet<string>();


            while (input!= "PARTY")
            {
                if (Char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input!="END")
            {
                if (Char.IsDigit(input[0]))
                {
                    if (vip.Contains(input))
                    {
                        vip.Remove(input);
                    }
                }
                else
                {
                    if (regular.Contains(input))
                    {
                        regular.Remove(input);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(vip.Count+regular.Count);
            if (vip.Count>0)
            {
                Console.WriteLine(String.Join("\n", vip));
            }
            if (regular.Count>0)
            {
                Console.WriteLine(String.Join("\n", regular));
            }
                
            

        }
    }
}
