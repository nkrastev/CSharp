using Ex04WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Core
{
    public class Engine
    {
        
        public void Run()
        {
            List<Animal> listOfAnimals = new List<Animal>();

            

            while (true)
            {
                var firstInput = Console.ReadLine();
                if (firstInput == "End")
                {
                    break;
                }
                var secondInput = Console.ReadLine();
                if (secondInput == "End")
                {
                    break;
                }

                //logic
                var first = firstInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var second = secondInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //creating animals and adding to list
                Animal animal = null;

                try
                {
                    if (first[0] == "Owl")
                    {
                        animal = new Owl(first[1], double.Parse(first[2]), double.Parse(first[3]));
                    }
                    else if (first[0] == "Hen")
                    {
                        animal = new Hen(first[1], double.Parse(first[2]), double.Parse(first[3]));
                    }
                    else if (first[0] == "Mouse")
                    {
                        animal = new Mouse(first[1], double.Parse(first[2]), first[3]);
                    }
                    else if (first[0] == "Dog")
                    {
                        animal = new Dog(first[1], double.Parse(first[2]), first[3]);
                    }
                    else if (first[0] == "Cat")
                    {
                        animal = new Cat(first[1], double.Parse(first[2]), first[3], first[4]);
                    }
                    else if (first[0] == "Tiger")
                    {
                        animal = new Tiger(first[1], double.Parse(first[2]), first[3], first[4]);
                    }

                    Console.WriteLine(animal.ProduceSound());
                    
                    //add to list
                    listOfAnimals.Add(animal);

                    //feed them
                    var currentFood = second[0];
                    var currentQuantity = int.Parse(second[1]);


                    animal.Feed(currentFood, currentQuantity);
                    
                    //update data in the list
                    listOfAnimals.RemoveAt(listOfAnimals.Count - 1);
                    listOfAnimals.Add(animal);
                    
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
            }

            foreach (var animal in listOfAnimals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
