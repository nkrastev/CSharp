using System;
using System.Collections.Generic;
using System.Text;

namespace Ex09PokemonTrainer
{
    public class Trainer
    {
        //fields
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        //constructor
        public Trainer(string name, int badges, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.Badges = badges;
            this.Pokemons = new List<Pokemon>();
        }

        //prop
        public string Name { get; set; }
        public int Badges 
        {
            get { return this.badges; }
            //set default value
            set { this.badges = value; }
        }
        public List<Pokemon> Pokemons { get; set; }
    }
}
