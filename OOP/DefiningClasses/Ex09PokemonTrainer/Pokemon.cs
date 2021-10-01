using System;
using System.Collections.Generic;
using System.Text;

namespace Ex09PokemonTrainer
{
    public class Pokemon
    {
        //fields
        private string name;
        private string element;
        private int health;

        //constructor
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        //properties
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
