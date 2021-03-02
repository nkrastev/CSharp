using System;

namespace Ex01ClassBoxData
{
    public class StartUp
    {
        static void Main()
        {
            var lenght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());            

            try
            {
                var box = new Box(lenght, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");                
                Console.WriteLine($"Lateral Surface Area - {box.Lateral():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                        
        }
    }
}
