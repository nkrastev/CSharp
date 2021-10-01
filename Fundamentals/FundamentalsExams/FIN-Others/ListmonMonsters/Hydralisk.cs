using System;
using System.Collections.Generic;
using System.Text;

namespace _02ListmonMonsters
{
    public class Hyrdalisk
    {
        //constructor
        public Hyrdalisk(string name, int id, int strenght, int ugliness, string range)
        {
            Name = name;
            Id = id;
            Strength = strenght;
            Ugliness = ugliness;
            Range = range;
        }
        //properties
        public string Name { get; set; }
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Ugliness { get; set; }
        public string Range { get; set; }
    }
}
