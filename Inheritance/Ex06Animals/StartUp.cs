using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string END_OF_COMMANDS = "Beast!";
        
            var command = Console.ReadLine(); //type of animal                       
            var animalsList = new List<Animal>();

            while (command != END_OF_COMMANDS)
            {
                var animalData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); //animal data

                string name = animalData[0];
                int age = int.Parse(animalData[1]);

                Animal currentAnimal = null;
                
                if (command=="Dog")
                {
                    currentAnimal = new Dog(name, age, animalData[2]);
                }
                else if (command=="Cat")
                {
                    currentAnimal = new Cat(name, age, animalData[2]);
                }
                else if (command=="Frog")
                {
                    currentAnimal = new Frog(name, age, animalData[2]);
                }
                else if (command=="Kitten")
                {
                    currentAnimal = new Kitten(name, age);
                }
                else if (command=="Tomcat")
                {
                    currentAnimal = new Tomcat(name, age);
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }

                animalsList.Add(currentAnimal);
                

            }
            
            //output
            foreach (var item in animalsList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
