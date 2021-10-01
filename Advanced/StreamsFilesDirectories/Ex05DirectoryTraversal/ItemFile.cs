using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05DirectoryTraversal
{
    public class ItemFile
    {
        //Items ItemFile is actually File, but name is change not to be confused with File from System IO

        //constructor
        public ItemFile(string name, string extension, double size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }
        //properties
        public string Name { get; set; }
        public string Extension { get; set; }
        public double Size { get; set; }
    }
}
