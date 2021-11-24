namespace BookShop.Data.Models
{
    public class AuthorBook
    {
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }

/*    •	AuthorId - integer, Primary Key, Foreign key(required)
•	Author -  Author
•	BookId - integer, Primary Key, Foreign key(required)
•	Book - Book*/

}