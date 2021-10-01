using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        //fields

        //ctor

        //properties



        //methods
        public static T[] Create<T>(int length, T item)
        {
            T[] arr = new T[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = item;
            }
            return arr;
        }
    }
}
