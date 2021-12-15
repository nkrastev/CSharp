namespace MyWebServer
{
    using MyWebServer.Server;
    using System;
    using System.Threading.Tasks;
    public class StartUp
    {
        static async Task Main()
        {
            try
            {
                var server = new HttpServer("127.0.0.1", 5050);
                await server.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
