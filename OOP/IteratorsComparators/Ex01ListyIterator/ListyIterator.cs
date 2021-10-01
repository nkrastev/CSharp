using System;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator <T>
    {
        //fields
        private int currentIndex;
        private List<T> items;



        //ctor
        public ListyIterator(List<T> initialItems)
        {
            this.currentIndex = 0;
            this.items = initialItems;
        }

        //prop
        public int Count => this.items.Count;
        //public T Current { get; set; }

        //methods
        public bool HasNext()
        {
            if (this.currentIndex<this.Count-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.items[this.currentIndex]);
        }
    }
}
