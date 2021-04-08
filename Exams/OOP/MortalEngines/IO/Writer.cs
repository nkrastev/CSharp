using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MortalEngines.IO.Contracts
{
    public class Writer : IWriter
    {
        string path = "../../../Output.txt";

        public Writer()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write("");
            }
        }
        public void Write(string line)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {                
                writer.Write(line);
            }
        }

        public void WriteLine(string line)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(line);
            }
        }
    }
}
