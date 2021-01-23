using System;
using System.Collections.Generic;
using System.Text;

namespace Ex09CustomHashSet
{
    public class CustomSet
    {
        //fields
        int size = 8;
        private List<string>[] internalArray;

        //ctor
        public CustomSet(int capacity = 8)
        {
            size = capacity * 8;
            internalArray = new List<string>[size];
        }

        //methods
        public void Add(string element)
        {
            int index = HashFunction(element);

            if (internalArray[index]==null)
            {
                //create new list on position from hash function and add element in current list
                internalArray[index] = new List<string>{element};
            }
            else
            {
                //add element to current list
                internalArray[index].Add(element);
            }

        }
        public bool Contains(string element)
        {
            int index = HashFunction(element);
            if (internalArray[index]!=null)
            {
                for (int i = 0; i < internalArray[index].Count; i++)
                {
                    if (internalArray[index][i]==element)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int HashFunction(string element)
        {
            //find positions in the array behind the hashset
            //external hash function, or Math.Abs(GetHashCode())

            return Math.Abs(element.GetHashCode()) % size;

            //int sum = 0;
            //for (int i = 0; i < element.Length; i++)
            //{
            //    sum += element[i];
            //}
            //return sum % size;

            //UInt64 hashedValue = 3074457345618258791ul;
            //for (int i = 0; i < read.Length; i++)
            //{
            //    hashedValue += read[i];
            //    hashedValue *= 3074457345618258799ul;
            //}
            //return hashedValue;
        }

    }
}
