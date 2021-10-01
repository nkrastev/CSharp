using System;
using System.Linq;
using System.Text;

namespace ALab4TextFilter
{
    class Program
    {
        static void Main()
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string text = Console.ReadLine();

            

            Console.WriteLine(CheckAndReplace(text, bannedWords));

        }

        private static string CheckAndReplace(string text, string[] bannedWords)
        {
            foreach (var item in bannedWords)
            {
                while (text.Contains(item))
                {
                    //construct replacement string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < item.Length; i++)
                    {
                        sb.Append("*");
                    }
                    string stringToBeReplaced = sb.ToString();
                    text=text.Replace(item, stringToBeReplaced);
                }
            }
            return text;
        }
    }
}
