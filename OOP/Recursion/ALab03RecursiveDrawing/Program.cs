using System;

namespace ALab03RecursiveDrawing
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Draw(n);
        }

        private static void Draw(int n)
        {
            if (n<=0)
            {
                return;
            }

            Console.WriteLine(new string('*',n));
            Draw(n - 1);
            Console.WriteLine(new string('#',n));
        }
    }
}
