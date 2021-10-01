using System;
using System.Linq;

namespace Mo03TreasureFinder
{
    class Program
    {
        static void Main()
        {
            int[] key = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input!="find")
            {
                Console.WriteLine($"Found {TreasureTypeFind(DecryptInput(input, key))} at {CoordinatesFinder(DecryptInput(input, key))}");
                input = Console.ReadLine();
            }
            
        }

        private static string CoordinatesFinder(string decryptedMessage)
        {
            string coordinates = "";
            int startIndex = decryptedMessage.IndexOf('<');
            int endIndex = decryptedMessage.IndexOf('>');
            coordinates=decryptedMessage.Substring(startIndex + 1, endIndex - startIndex - 1);
            return coordinates;
        }

        private static string TreasureTypeFind(string decryptedMessage)
        {
            string type = "";
            int startIndex = decryptedMessage.IndexOf('&');
            int endIndex = decryptedMessage.LastIndexOf('&');
            type = decryptedMessage.Substring(startIndex+1, endIndex - startIndex-1);
            return type;
        }

        private static string DecryptInput(string input, int[] key)
        {
            string decrypted = "";
            int sizeOfKey = key.Length;
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (j==sizeOfKey)
                {
                    j = 0;
                }
                int item = (int)input[i]-key[j];
                j++;                
                decrypted += (char)item;
            }
            return decrypted;
        }
    }
}
