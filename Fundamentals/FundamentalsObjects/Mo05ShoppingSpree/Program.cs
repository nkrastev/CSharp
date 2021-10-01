using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingSpree
{
    class Program
    {
        static void Main()
        {
            List<Person> peoplesList = new List<Person>();
            List<Product> priceList = new List<Product>();

            //read data
            string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            //split data and place it to the lists
            ReadPeoplesList(inputPeople, peoplesList);
            ReadPriceList(inputProducts, priceList);                       

            //buying commands
            string command = Console.ReadLine();
            while (command!="END")
            {                
                string[] purchase = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string purchasePerson = purchase[0];
                string purchaseProduct = purchase[1];

                //get product price, person budget, index in people's list
                double purchasePrice = priceList.Where(x => x.Name == purchaseProduct).Select(y=>y.Cost).First();                
                double purchaseBudget = peoplesList.Where(x => x.Name == purchasePerson).Select(y => y.Money).First();
                //int index = peoplesList.IndexOf(purchasePerson);

                //check if purchase is possible
                if (purchaseBudget>=purchasePrice)
                {
                    Console.WriteLine($"{purchasePerson} bought {purchaseProduct}");                    
                    //update budget
                    peoplesList.Where(x => x.Name == purchasePerson).ToList().ForEach(x => x.Money = purchaseBudget - purchasePrice);
                    //add product to the list                    
                    Person buyer = peoplesList.FirstOrDefault(x => x.Name == purchasePerson);
                    buyer.BagProducts.Add(purchaseProduct);                    
                }
                else
                {
                    Console.WriteLine($"{purchasePerson} can't afford {purchaseProduct}");
                }

                command = Console.ReadLine();
            }

            //output Persons with products in bags
            PrintPersonsAndBags(peoplesList);

        }

        private static void PrintPersonsAndBags(List<Person> peoplesList)
        {
            foreach (Person item in peoplesList)
            {
                Console.Write($"{item.Name} - ");
                if (item.BagProducts.Count==0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(String.Join(", ",item.BagProducts));
                }
            }
        }

        private static List<Product> ReadPriceList(string[] inputProducts, List<Product> priceList)
        {
            for (int i = 0; i < inputProducts.Length; i++)
            {
                string[] inputSeparateProduct = inputProducts[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Product productItem = new Product(inputSeparateProduct[0], double.Parse(inputSeparateProduct[1]));
                priceList.Add(productItem);
            }
            return priceList;
        }

        private static List<Person> ReadPeoplesList(string[] inputPeople, List<Person> peoplesList)
        {
            for (int i = 0; i < inputPeople.Length; i++)
            {
                string[] inputSeparatePerson = inputPeople[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person personItem = new Person(inputSeparatePerson[0], double.Parse(inputSeparatePerson[1]), new List<string>());
                peoplesList.Add(personItem);
            }
            return peoplesList;
        }
    }

    class Person
    {
        //constructor
        public Person(string name, double money, List<string> bagOfProducts)
        {
            Name = name;
            Money = money;
            BagProducts = bagOfProducts;
        }
        //properties
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> BagProducts { get; set; }

        
    }

    class Product
    {
        //constructor
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        //properties
        public string Name { get; set; }

        public double Cost { get; set; }        

    }

}
