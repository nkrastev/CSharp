using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
    class Program
    {        
        const string NEW_LINE = "\r\n";        
        const int PORT = 8000;

        static async Task Main(string[] args)
        {
            try
            {                
                await TcpListenerStreamRead();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task TcpListenerStreamRead()
        {
            List<string> tweets = new List<string>();
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, PORT);
            tcpListener.Start();
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                byte[] buffer = new byte[1000000];

                using (var stream = client.GetStream())
                {
                    var lenght = stream.Read(buffer, 0, buffer.Length);
                    string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);
                                                          
                    string[] requestLines = requestString.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    string response = "";

                    foreach (var line in requestLines)
                    {
                        Console.WriteLine(line);
                        if (line == "POST / HTTP/1.1")
                        {
                            response = "HTTP/1.1 200 OK" + NEW_LINE +
                            "Server: NikiServer 2021" + NEW_LINE +
                            "Content-Type: text/html; charset=uft-8" + NEW_LINE +
                            "Content-Lenght: " + HtmlHomePage().Length + NEW_LINE +
                            NEW_LINE +
                            HtmlHomePage() +
                            NEW_LINE;
                        }
                        if (line.Contains("tweetContent"))
                        {                            
                            tweets.Add(line.Substring(13));
                            response = "HTTP/1.1 200 OK" + NEW_LINE +
                            "Server: NikiServer 2021" + NEW_LINE +
                            "Content-Type: text/html; charset=uft-8" + NEW_LINE +
                            "Content-Lenght: " + HtmlHomePage().Length+HtmlAllTweetsPage(tweets).Length + NEW_LINE +
                            NEW_LINE +
                            HtmlHomePage() + HtmlAllTweetsPage(tweets) +
                            NEW_LINE;
                        }                        
                    }                    
                    
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);
                }

            }
        }

        public static string HtmlHomePage()
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<h1>Home, Insert Tweet</h1>");
            htmlBuilder.AppendLine("<form method=\"POST\">");
            htmlBuilder.AppendLine("<input name=tweetContent />");
            htmlBuilder.AppendLine("<input type=submit />");
            htmlBuilder.AppendLine("</form>");

            return htmlBuilder.ToString();
        }

        public static string HtmlAllTweetsPage(List<string> allTweets)
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<h1>All Tweets</h1>");
            htmlBuilder.AppendLine("<ul>");
            foreach (var item in allTweets)
            {
                htmlBuilder.AppendLine($"<li>{item}</li>");
            }
            htmlBuilder.AppendLine("</ul>");           

            return htmlBuilder.ToString();
        }
    }
}
