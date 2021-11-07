using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class Program
    {
        static async Task Main()
        {
            const string URL = "https://www.softuni.bg/";

            await ReadData(URL);
        }

        public static async Task ReadData(string url)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Bypass the certificate, open connection, get response
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync(url);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.FirstOrDefault())));
        }
    }
}
