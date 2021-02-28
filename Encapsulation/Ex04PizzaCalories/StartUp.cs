using System;

namespace Ex04PizzaCalories
{
    class StartUp
    {
        static void Main()
        {
            try
            {
                /*Pizza Meatless
                Dough Wholegrain Crispy 100
                Topping Veggies 50
                Topping Cheese 50
                END
                */
                var inputPizza = Console.ReadLine().Split(' ');
                Pizza pizza = new Pizza(inputPizza[1]);

                var inputDough = Console.ReadLine().Split(' ');
                pizza.Dough = new Dough(inputDough[1], inputDough[2], double.Parse(inputDough[3]));

                var inputTopping = Console.ReadLine();
                while (inputTopping.ToLower()!="end")
                {
                    var input = inputTopping.Split(' ');
                    Topping newTopping = new Topping(input[1], double.Parse(input[2]));
                    pizza.AddTopping(newTopping);
                    inputTopping = Console.ReadLine();
                }

                Console.WriteLine(pizza);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
