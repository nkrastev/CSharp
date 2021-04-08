using MortalEngines.Core;
using MortalEngines.IO;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
           
            IReader reader = new Reader();
            IWriter writer = new Writer();           

            Engine engine = new Engine(reader, writer);
            
            engine.Run();
            
        }
    }
}