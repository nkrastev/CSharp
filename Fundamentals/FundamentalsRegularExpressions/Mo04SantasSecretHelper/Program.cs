using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SantasSecretHelper
{
    class Program
    {
        static void Main()
        {
            int decryptionKey = int.Parse(Console.ReadLine());
            string message = Console.ReadLine();
            List<string> children = new List<string>();

            while (message!="end")
            {
                string decryptedMessage = DecryptMethod(message, decryptionKey);                
                ValidMatchCheck(decryptedMessage, children);
                Console.WriteLine();
                message = Console.ReadLine();
            }
            PrintOutput(children);            
        }

        private static void PrintOutput(List<string> children)
        {
            foreach (var item in children)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> ValidMatchCheck(string decryptedMessage, List<string> children)
        {
            Regex regex = new Regex(@"@([A-Za-z]+)[^@\-!:>]*!([G|N])!");
            MatchCollection matches = regex.Matches(decryptedMessage);
            foreach (Match item in matches)
            {
                if (item.Groups[2].Value=="G")
                {
                    children.Add(item.Groups[1].Value);
                }                
            }
            return children; 
        }

        private static string DecryptMethod(string message, int decryptionKey)
        {
            string decrypted = "";
            for (int i = 0; i < message.Length; i++)
            {
                decrypted += (char)(message[i] - (char)(decryptionKey));                
            }            
            return decrypted;
        }
    }
}
