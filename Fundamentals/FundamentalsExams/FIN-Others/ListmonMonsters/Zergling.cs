using System;
using System.Collections.Generic;
using System.Text;

namespace _02ListmonMonsters
{
    public class Zergling
    {
        //constructor
        public Zergling(string name, int id, int strenght, int ugliness, int speed)
        {
            Name = name;
            Id = id;
            Strength = strenght;
            Ugliness = ugliness;
            Speed = speed;
        }
        //properties
        public string Name { get; set; }
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Ugliness { get; set; }
        public int Speed { get; set; }
    }
}
