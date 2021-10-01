using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        //fields
        private string name;

        //ctor
        public Animal(string name)
        {
            this.Name = name;
        }

        //prop
        public string Name { get; set; }
    }
}
