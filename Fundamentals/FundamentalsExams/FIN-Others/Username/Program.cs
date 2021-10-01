using System;
using System.Linq;

namespace Username
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var command = Console.ReadLine();
            while (command!= "Sign up")
            {
                var cmdAgrs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdAgrs[0]== "Case")
                {
                    if (cmdAgrs[1]== "lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                    if (cmdAgrs[1]== "upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                }
                if (cmdAgrs[0]== "Reverse")
                {
                    var startIndex = int.Parse(cmdAgrs[1]);
                    var endIndex = int.Parse(cmdAgrs[2]);
                    if (startIndex>=0 && startIndex<input.Length && endIndex>=0 && endIndex<input.Length)
                    {
                        if (startIndex>endIndex)
                        {
                            var temp = startIndex;
                            startIndex = endIndex;
                            endIndex = temp;
                        }
                        var substringItem = input.Substring(startIndex, endIndex - startIndex+1);
                        char[] charArray = substringItem.ToCharArray();
                        Array.Reverse(charArray);
                        Console.WriteLine(charArray);
                    }
                }
                if (cmdAgrs[0]=="Cut")
                {
                    var substringItem = cmdAgrs[1];
                    if (input.Contains(substringItem))
                    {
                        input = input.Replace(substringItem, "");
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine($"The word {input} doesn't contain {substringItem}.");
                    }
                }
                if (cmdAgrs[0]== "Replace")
                {
                    input = input.Replace(cmdAgrs[1], "*");
                    Console.WriteLine(input);
                }
                if (cmdAgrs[0]== "Check")
                {
                    var forCheck = char.Parse(cmdAgrs[1]);
                    if (input.Contains(forCheck))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {forCheck}.");
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
