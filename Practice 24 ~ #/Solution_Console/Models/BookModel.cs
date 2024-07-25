using Solution_Console.Models.Validations;
using System;
using System.Collections.Generic;


namespace Solution_Console.Models
{
    public class BookModel
    {
        public static int id { get; private set; }
        public int thisId { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Izdatelstvo { get; set; }
        public int CountPages {  get; set; }
        public int year { get; set; }

        public static int yearTarget = 2000;
        private static List<BookModel> books_ = new List<BookModel>();
        public static List<BookModel> books { get => books_; }
        private static List<BookModel> booksAll_ = new List<BookModel>();
        public static List<BookModel> booksAll { get => booksAll_; }

        public BookModel(string title, string author, string Izdatelstvo, int CountPages, int year) {
            this.Title = title;
            this.Author = author;
            this.Izdatelstvo = Izdatelstvo;
            this.CountPages = CountPages;
            this.year = year;
            BookValidation.Validate(this);
            id++;
            thisId = id;
            if(this.year > yearTarget)
            {
                books_.Add(this);
            }
            booksAll_.Add(this);
        }
        public override string ToString()
        {
            return $"Book: {this.Title} of author: {this.Author} by year {this.year}\npages: {this.CountPages} Publisher named: {this.Izdatelstvo}";
        }

    }
}
