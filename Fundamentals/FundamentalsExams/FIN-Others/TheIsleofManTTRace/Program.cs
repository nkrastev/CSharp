using System;
using System.Text.RegularExpressions;

namespace TheIsleofManTTRace
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var name = string.Empty;
                var lenght = 0;
                var geohash = string.Empty;
                Regex regex = new Regex(@"([#$%\*&])([A-Za-z]+)(\1)=([0-9]+)!!(.*)");
                MatchCollection matches = regex.Matches(input);
                foreach (Match item in matches)
                {
                    name = item.Groups[2].Value;
                    lenght = int.Parse(item.Groups[4].Value);
                    geohash = item.Groups[5].Value;
                }

                if (lenght>0 && geohash.Length>0 && lenght==geohash.Length)
                {
                    var decrypted = string.Empty;
                    for (int i = 0; i < geohash.Length; i++)
                    {
                        decrypted += (char)(geohash[i] + lenght);
                    }
                    Console.WriteLine($"Coordinates found! {name} -> {decrypted}");
                    break;
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
