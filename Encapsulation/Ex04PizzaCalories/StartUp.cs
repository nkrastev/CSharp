using Ex04PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                //TestDough();
                //TestToppings();
                
                var inputPizza = Console.ReadLine().Split();              
                var inputDough = Console.ReadLine().Split();

                var dough = new Dough(inputDough[1], inputDough[2], double.Parse(inputDough[3]));

                //Create Pizza with NO toppings                
                Pizza pizza = new Pizza(inputPizza[1], dough);              

                //Loop for toppings                                                                             
                while (true)
                {
                    var inputTopping = Console.ReadLine();
                    if (inputTopping== "END")
                    {
                        break;
                    }
                    //add topping to pizza
                    var data = inputTopping.Split();
                    //data[0] is Topping by default, create dought with data[1] type, and data[2] weight
                    var newTopping = new Topping(data[1], double.Parse(data[2]));
                    pizza.AddTopping(newTopping);                    
                }

                Console.WriteLine(pizza.ToString());

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);                
            }

        }

        //test methods
        public static void TestDough()
        {
            var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();            
            var dough = new Dough(data[1], data[2], int.Parse(data[3]));
            Console.WriteLine(dough.CaloriesPerGram());                        
        }

        public static void TestToppings()
        {
            var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();            
            var topping = new Topping(data[1], int.Parse(data[2]));
            Console.WriteLine(topping.CaloriesPerGram());            
        }

    }
}
