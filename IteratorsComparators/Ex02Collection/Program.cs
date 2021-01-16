using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            var input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    var cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var command = cmdArgs[0];

                    if (command == "Create")
                    {
                        List<string> elements = cmdArgs.Skip(1).ToList();
                        listyIterator = new ListyIterator<string>(elements);
                    }
                    if (command == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    if (command == "Print")
                    {
                        listyIterator.Print();
                    }
                    if (command == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    if (command == "PrintAll")
                    {
                        listyIterator.PrintAll();
                    }

                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
