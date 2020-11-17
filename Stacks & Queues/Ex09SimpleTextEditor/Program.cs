using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> stackCommands = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0]=="1")
                {
                    //1 someString - appends someString to the end of the text
                    sb.Append(command[1]);
                    stackCommands.Push(command[0]+" "+command[1]);
                }
                if (command[0]=="2")
                {
                    //2 count - erases the last count elements from the text
                    int countElements = int.Parse(command[1]);
                    if (countElements<=sb.Length)
                    {
                        string deletedPart = sb.ToString(sb.Length - countElements, countElements);
                        sb.Remove(sb.Length - countElements, countElements);                        
                        stackCommands.Push("2 "+deletedPart);
                    }
                }
                if (command[0]=="3")
                {
                    //3 index - returns the element at position index from the text
                    int index = int.Parse(command[1])-1;
                    if (index>=0 && index<sb.Length)
                    {
                        Console.WriteLine(sb[index]);
                    }                   
                }
                if (command[0]=="4")
                {
                    //4 undo the last command of type 1 || 2
                    string[] lastCommand = stackCommands.Pop().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (lastCommand[0]=="1")
                    {
                        //lastCommand[1] has been appended to SB, so remove it
                        int countToRemove = lastCommand[1].Length;
                        sb.Remove(sb.Length - countToRemove, countToRemove);
                    }
                    if (lastCommand[0]=="2")
                    {
                        //lastCommand[1] is the deleted part, put it back to SB
                        sb.Append(lastCommand[1]);
                    }
                }
            }

        }
    }
}
