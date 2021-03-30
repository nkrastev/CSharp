using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {

        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        //private int tableNumber;
        private int numberOfPeople;
        //private decimal pricePerPerson;
        private bool isReserved;
        private int capacity;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();            

        }

        public int TableNumber
        {
            get;            
        }

        public int Capacity
        {
            get => this.capacity;
            private set 
            {
                //capacity can’t be less than zero ???? BUT CAN IT BE ZERO?
                if (value<0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
            
        }
        
        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value; 
            }
        }
       
        public decimal PricePerPerson
        {
            get;        
        }

      
        public bool IsReserved
        {
            get { return isReserved;}
            private set { this.isReserved = value; }
        }
        

        public decimal Price => foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price)+this.NumberOfPeople* this.PricePerPerson;


        public void Clear()
        {
            //Removes all of the ordered drinks and food and finally frees the table and sets the count of people to 0.
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.IsReserved = false;
            this.Capacity = 0;
        }

        public decimal GetBill() => this.Price;


        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
