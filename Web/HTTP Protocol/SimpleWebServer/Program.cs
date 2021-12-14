using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class Program
    {
        const string URL = "https://www.softuni.bg/";
        const string NEW_LINE = "\r\n";

        const string HTML_HOME = "<h1>Home page HTML</h1>";
        const string HTML_CONTACTS= "<h1>Contacts page HTML</h1>";        
        const string HTML_PRODUCTS = "<h1>Products page HTML</h1>";
        const string HTML_Default = "<h1>Default page HTML</h1>";

        static async Task Main()
        {
            try
            {
                //await ReadData(URL);
                await TcpListenerStreamRead();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                       

        }

        public static async Task TcpListenerStreamRead()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 55555);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                byte[] buffer = new byte[1000000];

                using (var stream = client.GetStream())
                {
                    var lenght = stream.Read(buffer, 0, buffer.Length);
                    var html = HTML_Default;
                    string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);

                    //load different response based on request string                                        
                    string[] requestLines = requestString.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    var htmlToLoad = HTML_Default;

                    foreach (var line in requestLines)
                    {
                        if (line== "GET / HTTP/1.1")
                        {
                            htmlToLoad = HTML_HOME;
                        }
                        else if (line == "GET /contacts HTTP/1.1")
                        {
                            htmlToLoad = HTML_CONTACTS;
                        }
                        else if (line == "GET /products HTTP/1.1")
                        {
                            htmlToLoad = HTML_PRODUCTS;
                        }                    
                    }
                    Console.WriteLine($"Load response, based on GET route.");
                    string response = "HTTP/1.1 200 OK" + NEW_LINE +
                        "Server: NikiServer 2021" + NEW_LINE +
                        "Content-Type: text/html; charset=uft-8" + NEW_LINE +
                        "Content-Lenght: " + htmlToLoad.Length + NEW_LINE +
                        NEW_LINE +
                        htmlToLoad +
                        NEW_LINE;
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);
                }

            }
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
