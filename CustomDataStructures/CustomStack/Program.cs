using System;

namespace CustomStack
{
    class Program
    {
        static void Main()
        {
            CustomStack customStack = new CustomStack();
            customStack.Push(10);
            customStack.Push(20);
            customStack.Push(30);

            customStack.Pop();
            
            customStack.ForEach(x => Console.WriteLine(x));            
        }
        
    }
}
