using System;
using System.Collections.Generic;
using System.Linq;

namespace _3SchoolLibrary
{
    class Program
    {
        static void Main()
        {
            List<string> books = Console.ReadLine()
                .Split("&", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] commandItems = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandItems[0] == "Add Book")
                {
                    string bookName = commandItems[1];
                    AddBook(books, bookName);
                }

                if (commandItems[0] == "Take Book")
                {
                    string bookName = commandItems[1];
                    TakeBook(books, bookName);
                }

                if (commandItems[0] == "Swap Books")
                {
                    string book1 = commandItems[1];
                    string book2 = commandItems[2];
                    SwapBooks(books, book1, book2);
                }

                if (commandItems[0]== "Insert Book")
                {
                    string bookName = commandItems[1];
                    books.Add(bookName);
                }

                if (commandItems[0]== "Check Book")
                {
                    int index = int.Parse(commandItems[1]);
                    if (index>=0 && index<books.Count)
                    {
                        Console.WriteLine(books[index]);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ",books));

        }

        private static List<string> SwapBooks(List<string> books, string book1, string book2)
        {
            if (books.Contains(book1) && books.Contains(book2))
            {                
                int index1 = books.IndexOf(book1);
                int index2 = books.IndexOf(book2);
                books[index1] = book2;
                books[index2] = book1;
            }
            return books;
        }

        private static List<string> TakeBook(List<string> books, string bookName)
        {
            if (books.Contains(bookName))
            {
                books.Remove(bookName);
            }

            return books;
        }

        private static List<string> AddBook(List<string> books, string bookName)
        {
            if (!books.Contains(bookName))
            {
                books.Insert(0, bookName);
            }
            return books;
        }
    }
}
