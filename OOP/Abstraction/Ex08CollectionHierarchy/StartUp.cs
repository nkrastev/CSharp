using Ex08CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08CollectionHierarchy
{
    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var numberOfRemoveCommands = int.Parse(Console.ReadLine());

            var firstCollection = new AddCollection();
            var secondCollection = new AddRemoveCollection();
            var thirdCollection = new MyList();

            var firstResult = new List<int>();
            var secondResult = new List<int>();
            var thirdResult = new List<int>();

            //fill in collections
            for (int i = 0; i < input.Length; i++)
            {
                firstResult.Add(firstCollection.Add(input[i]));
                secondResult.Add(secondCollection.Add(input[i]));
                thirdResult.Add(thirdCollection.Add(input[i]));
            }
            //remove commands
            var fourthResult = new List<string>();
            var fifthResult = new List<string>();

            for (int i = 0; i < numberOfRemoveCommands; i++)
            {
                fourthResult.Add(secondCollection.Remove());
                fifthResult.Add(thirdCollection.Remove());
            }

            Console.WriteLine(String.Join(" ",firstResult));
            Console.WriteLine(String.Join(" ",secondResult));
            Console.WriteLine(String.Join(" ",thirdResult));
            Console.WriteLine(String.Join(" ", fourthResult));
            Console.WriteLine(String.Join(" ", fifthResult));

            
        }
    }
}
