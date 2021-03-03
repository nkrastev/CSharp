using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05BirthdayCelebrations
{
    public class Citizen : IIdentity, IBirthdate
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get => this.id; set => this.id = value; }
        public string Birthdate { get=> this.birthdate; set=> this.birthdate=value; }
    }
}
