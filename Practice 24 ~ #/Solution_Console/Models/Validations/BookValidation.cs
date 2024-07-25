using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Console.Models.Validations
{
    public class BookValidation
    {
        public static void Validate(BookModel book)
        {
            if(book.CountPages < 5 || book.CountPages > 1000)
            {
                throw new Exception("Book do not contains this pages!!!");
            }
            if(book.year > DateTime.Now.Year || book.year < 1500)
            {
                throw new Exception("Book year is invalid");
            }
            if(book.Title.Length > 40)
            {
                throw new Exception("title lenght exception");
            }
        } 
    }
}
