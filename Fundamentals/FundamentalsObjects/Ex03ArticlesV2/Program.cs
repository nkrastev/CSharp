using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03Articles
{
    class Program
    {
        static void Main()
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articlesList = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                // read the data
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                //new instance of article type, fill it with data
                Article itemArticle = new Article(input[0], input[1], input[2]);

                //add instance to the list
                articlesList.Add(itemArticle);
            }

            //order
            string orderCommand = Console.ReadLine();
            if (orderCommand == "title")
            {
                articlesList = articlesList.OrderBy(item => item.Title).ToList();
            }
            if (orderCommand == "content")
            {
                articlesList = articlesList.OrderBy(item => item.Content).ToList();
            }
            if (orderCommand == "author")
            {
                articlesList = articlesList.OrderBy(item => item.Author).ToList();
            }


            //output
            foreach (Article item in articlesList)
            {
                Console.WriteLine(item.ToString());
            }

        }

    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;

        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
