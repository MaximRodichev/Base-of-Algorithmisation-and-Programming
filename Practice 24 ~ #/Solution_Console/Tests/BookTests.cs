using Solution_Console.Models;
using Solution_Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Instructs.Instructions;

namespace Solution_Console.Tests
{
    public class BookTests
    {
        public static void CreationTest()
        {
            infoWithStrikeLine("CreationTest Starts");
            List<string> titles = new List<string>
        {
            "To Kill a Mockingbird",
            "1984",
            "The Great Gatsby",
            "Pride and Prejudice",
            "Harry Potter and the Philosopher's Stone",
            "The Catcher in the Rye",
            "The Lord of the Rings"
        };

            List<string> authors = new List<string>
        {
            "Harper Lee",
            "George Orwell",
            "F. Scott Fitzgerald",
            "Jane Austen",
            "J.K. Rowling",
            "J.D. Salinger",
            "J.R.R. Tolkien"
        };

            List<string> publishers = new List<string>
        {
            "HarperCollins Publishers",
            "Penguin Books",
            "Scribner",
            "Penguin Classics",
            "Bloomsbury Publishing",
            "Little, Brown and Company",
            "Mariner Books"
        };

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                string title = titles[rnd.Next(titles.Count)];
                string author = authors[rnd.Next(authors.Count)];
                string publisher = publishers[rnd.Next(publishers.Count)];
                int countpages = rnd.Next(5, 1100);
                int year = rnd.Next(1400, 2100);
                BookRepository.CreateBook(
                    author,
                    title,publisher,countpages,year
                );
            }
            infoWithStrikeLine("You must create 2 books");
            BookRepository.CreateBook();
            BookRepository.CreateBook();

        }
        public static void OutBooks()
        {
        again:
            Console.Clear();
            infoWithStrikeLine($"Sportiks DATA, All Count: {BookModel.id}");
            BookRepository.GetBooksByYear();
            info("All Books see as:");
            BookRepository.GetBooks();
        }
    }
}
