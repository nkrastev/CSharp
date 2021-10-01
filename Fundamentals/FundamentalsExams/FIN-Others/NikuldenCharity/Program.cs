using System;
using System.Linq;

namespace NikuldenCharity
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var command = Console.ReadLine();
            while (command!= "Finish")
            {
                var cmdAgrs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdAgrs[0]== "Replace")
                {
                    var currentChar = char.Parse(cmdAgrs[1]);
                    var newChar = char.Parse(cmdAgrs[2]);
                    input = input.Replace(currentChar, newChar);
                    Console.WriteLine(input);
                }
                if (cmdAgrs[0]== "Cut")
                {
                    var startIndex = int.Parse(cmdAgrs[1]);
                    var endIndex = int.Parse(cmdAgrs[2]);
                    if (startIndex<0 ||startIndex>=input.Length || endIndex<0 || endIndex>=input.Length)
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                    else
                    {
                        if (startIndex>endIndex)
                        {
                            input = input.Remove(endIndex, startIndex - endIndex+1);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            input = input.Remove(startIndex, endIndex - startIndex+1);
                            Console.WriteLine(input);
                        }
                    }
                }
                if (cmdAgrs[0]== "Make")
                {
                    if (cmdAgrs[1]== "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    if (cmdAgrs[1]== "Lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }

                if (cmdAgrs[0]== "Check")
                {
                    if (input.Contains(cmdAgrs[1]))
                    {
                        Console.WriteLine($"Message contains {cmdAgrs[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {cmdAgrs[1]}");
                    }
                }
                if (cmdAgrs[0]=="Sum")
                {
                    var startIndex = int.Parse(cmdAgrs[1]);
                    var endIndex = int.Parse(cmdAgrs[2]);
                    if (startIndex < 0 || startIndex >= input.Length || endIndex < 0 || endIndex >= input.Length)
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                    else
                    {
                        if (startIndex>endIndex)
                        {
                            int temp = startIndex;
                            startIndex = endIndex;
                            endIndex = temp;
                        }
                        //indexes are valid
                        var substring = input.Substring(startIndex, endIndex - startIndex+1);
                        int sum = 0;
                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += (int)substring[i];
                        }
                        Console.WriteLine(sum);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
