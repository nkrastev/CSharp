using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            var sorted = books.ToList();
            sorted.Sort(new BookComparator());
            this.Books = sorted;            
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            //old interface
            return GetEnumerator();
        }

        //Enumerator without yield
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int curIndex;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public Book Current => this.books[this.curIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {                
            }

            public bool MoveNext()
            {
                return ++this.curIndex < this.books.Count;
            }

            public void Reset()
            {
                this.curIndex = -1;
            }
        }
    }
}
