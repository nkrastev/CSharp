using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01ValidUsernames
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<string> validList = new List<string>();

            CheckUsernames(input, validList);

            Console.WriteLine(String.Join("\n", validList));
        }

        private static List<string> CheckUsernames(string[] input, List<string> validList)
        {
            foreach (var item in input)
            {                
                if (item.Length >= 3 && item.Length <= 16)
                {
                    bool isValid = true;
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (!Char.IsDigit(item[i]) && !Char.IsLetter(item[i]) && item[i] != '-' && item[i] != '_')
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        validList.Add(item);
                    }
                }        
            }                   
            return validList;
        }
    }
}
