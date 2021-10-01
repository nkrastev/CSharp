using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            while (input!= "end")
            {
                Regex regex = new Regex(@"^[A-Z][a-z' ]+:[A-Z ]*");
                MatchCollection matches = regex.Matches(input);
                if (matches.Count>0)
                {
                    foreach (Match item in matches)
                    {
                        EncryptItem(item.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine();
            }
        }

        private static void EncryptItem(string item)
        {
            var data = item.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();            
            var key = data[0].Length;
            var encrypted = string.Empty;            
            //A-Z 65-90, a-z 97-122
            for (int i = 0; i < item.Length; i++)
            {                
                if (Char.IsLower(item[i]) && item[i] + key > 122)
                {
                    encrypted += (char)(96 + (item[i]-122 + key));                    
                }
                if (Char.IsLower(item[i]) && item[i] + key <= 122)
                {
                    encrypted+=(char)(item[i] + key);
                }
                if (Char.IsUpper(item[i])&& item[i]+key>90)
                {
                    encrypted += (char)(64 + (item[i]-90 + key));
                }
                if (Char.IsUpper(item[i])&& item[i]+key<=90)
                {
                    encrypted += (char)(item[i] + key);
                }
                if (item[i]==':')
                {
                    encrypted += '@';
                }
                if (item[i]==' ')
                {
                    encrypted += ' ';
                }
                if (item[i]=='\'')
                {
                    encrypted += '\'';
                }
            }
            Console.WriteLine(encrypted);
        }
    }
}
