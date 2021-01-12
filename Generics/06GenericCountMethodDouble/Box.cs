using System;
using System.Collections.Generic;
using System.Text;

namespace _06GenericCountMethodDouble
{
    public class Box<T>
        where T : IComparable
    {
        //fields        

        //ctor
        public Box()
        {
            this.Items = new List<T>();
        }

        //prop
        public List<T> Items
        {
            get;
            set;
        }

        //methods
        public void AddToList(T element)
        {
            this.Items.Add(element);
        }
        public List<T> Swap(int first, int second)
        {
            var temp = this.Items[first];
            this.Items[first] = this.Items[second];
            this.Items[second] = temp;

            return this.Items;
        }

        public int BiggerElements(T element)
        {
            var count = 0;

            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }


    }
}
