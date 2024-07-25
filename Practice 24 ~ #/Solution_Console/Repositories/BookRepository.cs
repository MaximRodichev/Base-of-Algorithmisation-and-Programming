using Solution_Console.Models;
using System;
using System.Collections.Generic;
using static Instructs.Instructions;

namespace Solution_Console.Repositories
{
    internal class BookRepositoryBase
    {
        internal static void CreateBook()
        {
            info($"Create a new book with id: {BookModel.id}");
        }
    }
    public class BookRepository
    {
        public static BookModel CreateBook()
        {
            BookRepositoryBase.CreateBook();
        again:
            string author = inputString("Author: ");
            string title = inputString("title: ");
            string publisher = inputString("publisher: ");
            int year = inputInt("year: ");
            int countPages = inputInt("countPages: ");
            BookModel book;
            try
            {
                book = new BookModel(
                    title,
                    author,
                    publisher,
                    countPages,
                    year
                    );
            }
            catch (Exception ex) { Error(ex.Message); goto again; }
            return book;
        }

        public static BookModel CreateBook(string author, string title, string publisher, int countpages, int year)
        {
            BookRepositoryBase.CreateBook();
            BookModel model;
            try
            {
                model = new BookModel(title, author, publisher, countpages, year);
                return model;
            }
            catch (Exception ex) { Error(ex.Message); return null; }

        }

        public static void GetBooksByYear()
        {
            List<BookModel> targetList;
            targetList = BookModel.books;
            foreach(BookModel book in targetList)
            {
                info(book.ToString());
            }
        }
        public static void GetBooks()
        {
            List<BookModel> targetList;
            targetList = BookModel.booksAll;
            foreach (BookModel book in targetList)
            {
                info(book.ToString());
            }
        }
    }
}
