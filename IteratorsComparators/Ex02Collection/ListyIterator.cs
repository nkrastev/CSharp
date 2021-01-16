using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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
                

        //methods
        public bool HasNext()
        {
            if (this.currentIndex < this.Count - 1)
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
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.items[this.currentIndex]);
        }

        public void PrintAll()
        {
            foreach (var item in items)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }




        //ENUMERATOR
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.items.Count; i++)
                yield return this.items[i];

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
