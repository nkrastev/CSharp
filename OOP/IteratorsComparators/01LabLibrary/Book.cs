using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
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
            this.Authors = authors;
        }

        //prop
        public string Title { get; set; }
        public int Year { get; set; }
        public string[] Authors
        {
            get;set;
        }
    }
}
