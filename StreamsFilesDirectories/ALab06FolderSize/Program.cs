using System;
using System.IO;

namespace ALab06FolderSize
{
    class Program
    {
        static void Main()
        {
            var totalSize = 0.0;
            foreach (string item in Directory.GetFiles("TestFolder"))
            {             
                FileInfo infoForFile = new FileInfo(item);
                totalSize += infoForFile.Length;                
            }
            var totalInMB = totalSize / 1024 / 1024;
            File.WriteAllText("output.txt", totalInMB.ToString());                      
        }
    }
}
