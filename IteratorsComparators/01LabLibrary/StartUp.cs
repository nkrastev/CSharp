using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);
            Book bookFour = new Book("The Documents in the Case 4", 1930);


            Library libraryTwo = new Library(bookOne, bookTwo, bookThree, bookFour);


            foreach (var item in libraryTwo)
            {
                Console.WriteLine(item.Title);
            }

        }
    }
}
