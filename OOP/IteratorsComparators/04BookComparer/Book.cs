using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        //fields
        private string title;
        private int year;
        private List<string> authors;

        //constructor       
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.authors = new List<string>(authors);
        }

        //prop
        public string Title { get; private set; }
        public int Year { get; private set; }
        public IReadOnlyList<string> Authors => this.authors.AsReadOnly();

        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);
            if (result==0)
            {
                result = this.Title.CompareTo(other.Title);
            }
            return result;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
