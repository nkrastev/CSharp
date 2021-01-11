using System;
using System.Collections.Generic;
using System.Text;

namespace _04GenericSwapMethodIntegers
{
    public class Box<T>
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

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Items.Count; i++)
            {
                //$"{this.Item.GetType()}: {this.Item}";
                sb.AppendLine($"{this.Items[i].GetType()}: {this.Items[i]}");
            }
            return sb.ToString();
        }


    }
}
