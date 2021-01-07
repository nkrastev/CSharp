using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main()
        {
            Box<string> box = new Box<string>();
            box.Add("1");
            box.Add("2");
            box.Add("3");
            Console.WriteLine(box.Remove());
            
            Console.WriteLine(box.Remove());

            Console.WriteLine(box.Count);

        }
    }
}
