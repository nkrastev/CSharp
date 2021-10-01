using System;
using System.Linq;

namespace Ex02Articles
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Article inputArticle = new Article(input[0], input[1], input[2]);



            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (command[0] == "Edit")
                {
                    inputArticle.Edit(command[1]);
                }
                if (command[0]== "ChangeAuthor")
                {
                    inputArticle.ChangeAuthor(command[1]);
                }
                if (command[0]=="Rename")
                {
                    inputArticle.Rename(command[1]);
                }
            }

            //output
            Console.WriteLine(inputArticle.ToString());


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

        public string Edit(string content)
        {
            this.Content = content;
            return Content;
        }
        public string ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
            return Author;
        }
        public string Rename(string newTitle)
        {
            Title = newTitle;
            return Title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
