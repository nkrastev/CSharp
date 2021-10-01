using System;

namespace Mo05DecryptingMessage
{
    class Program
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());

            DecryptMessage(key, numberOfLines);
        }


        static void DecryptMessage(int decryptKey, int lines)
        {
            string decryptedMessage = "";

            for (int i = 0; i < lines; i++)
            {
                char input = char.Parse(Console.ReadLine());
                decryptedMessage += (char)(input + decryptKey);


            }
            Console.WriteLine(decryptedMessage);
        }
    }
}
