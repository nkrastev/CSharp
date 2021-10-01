using System;
using System.Collections.Generic;
using System.Text;

namespace Ex06FoodShortage
{
    public class Citizen : IIdentity, IBirthdate, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; }
        public string Id { get => this.id; set => this.id = value; }
        public string Birthdate { get=> this.birthdate; set=> this.birthdate=value; }
        public int Food { get => this.food; set => this.food=value; }       

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
