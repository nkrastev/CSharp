using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main()
        {
            CustomStack<string> customStack = new CustomStack<string>();
            
            var input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    var cmd = input.Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (cmd[0]=="Pop")
                    {
                        customStack.Pop();
                    }
                    if (cmd[0]=="Push")
                    {                       
                        List<string> elements = cmd.Skip(1).ToList();
                        foreach (var item in elements)
                        {
                            customStack.Push(item);
                        }                        
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

        }

       
    }
}
