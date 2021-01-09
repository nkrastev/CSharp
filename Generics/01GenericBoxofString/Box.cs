using System;
using System.Collections.Generic;
using System.Text;

namespace _01GenericBoxofString
{
    public class Box<T>
    {
        //fields
        private T item;

        //ctor
        public Box()
        {
            
        }

        //prop
        public T Item { get; set; }

        //methods
        public override string ToString()
        {
            return $"{this.Item.GetType()}: {this.Item}";
        }

    }
}
