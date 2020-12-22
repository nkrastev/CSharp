using System;
using System.IO;

namespace ALab05SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("SliceMe.txt");
            var partition = Math.Ceiling(input.Length / (decimal)4);


            for (int i = 0; i < 3; i++)
            {
                //create the part 0-3
                var content = input.Substring((int)(i * partition), (int)(partition));
                File.WriteAllText($"Part-{i + 1}.txt", content);
            }

            //last file
            var contentLast = input.Substring((int)(3 * partition), input.Length-1- (int)(3 * partition));
            File.WriteAllText($"Part-4.txt", contentLast);
        }

    }
}
