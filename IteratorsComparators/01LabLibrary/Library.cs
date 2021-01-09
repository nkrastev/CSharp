using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library:IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.Books = books.ToList();
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.Books.Count; i++)
            {
                yield return this.Books[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
