using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AEBExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var urls = ReadUrls();
                var result = new List<string>();
                Console.OutputEncoding = System.Text.Encoding.UTF8;


                using (WebClient client = new WebClient())
                {                    
                    foreach (var url in urls)
                    {
                        string html = client.DownloadString(url);
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(html);

                        //var guideName=doc.DocumentNode.Descendants("h1").First().InnerHtml;                        

                        if (doc.DocumentNode.SelectNodes(@"//p[starts-with(@class, ""emails"")]") != null)
                        {
                            result.Add(doc.DocumentNode.SelectNodes(@"//p[starts-with(@class, ""emails"")]").FirstOrDefault().InnerText);
                        }
                        //IMPORTANT the result need to be Decoded                       
                    }

                }
                File.WriteAllLines("Result.txt", result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public static List<string> ReadUrls()
        {
            var data = new List<string>();

            foreach (string line in System.IO.File.ReadLines(@"guides.txt"))
            {
                data.Add(line);                
            }
            return data;
        }
    }
}
