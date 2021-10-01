using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex09PokemonTrainer
{
    class Program
    {
        static void Main()
        {
            var listTrainers = ReadData();

            var command = Console.ReadLine();
            while (command!= "End")
            {                
                foreach (Trainer item in listTrainers)
                {
                    if (item.Pokemons.Any(x=>x.Element==command))
                    {
                        item.Badges++;                        
                    }
                    else
                    {
                        //Otherwise, all of his pokemon lose 10 health. If a pokemon falls to 0 or less health, he dies 
                        foreach (Pokemon pokemonItem in item.Pokemons)
                        {
                            pokemonItem.Health -= 10;                            
                        }
                        //nice method name :D
                        RemoveDeathBodies(item.Pokemons);
                    }
                }
                command = Console.ReadLine();
            }
            //output
            foreach (Trainer item in listTrainers.OrderByDescending(x=>x.Badges))
            {
                Console.WriteLine($"{item.Name} {item.Badges} {item.Pokemons.Count}");
            }
            
        }

        private static List<Pokemon> RemoveDeathBodies(List<Pokemon> pokemons)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i].Health<=0)
                {
                    pokemons.RemoveAt(i);
                    i++;
                }
            }
            return pokemons;
        }

        private static List<Trainer> ReadData()
        {
            var trainers = new List<Trainer>();
            var command = Console.ReadLine();
            while (command!= "Tournament")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                Pokemon newPokemon = new Pokemon(cmdArgs[1], cmdArgs[2], int.Parse(cmdArgs[3]));
                if (trainers.Any(x=>x.Name==cmdArgs[0]))
                {
                    //there is such trainer, add pokemon at the current index
                    var index = trainers.FindIndex(x => x.Name == cmdArgs[0]);
                    trainers[index].Pokemons.Add(newPokemon);
                }
                else
                {
                    //create new trainer, add pokemon
                    Trainer newTrainer = new Trainer(cmdArgs[0], 0, new List<Pokemon>());
                    newTrainer.Pokemons.Add(newPokemon);
                    trainers.Add(newTrainer);
                }
                command = Console.ReadLine();
            }
            return trainers;
        }
    }
}
