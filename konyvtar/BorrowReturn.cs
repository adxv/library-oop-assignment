using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class BorrowReturn
    {
        public void BorrowBook(int id)
        {
            //find the book with the specified ID
            Book bookToBorrow = Library.books.Find(book => book.Id == id);

            //set
            bookToBorrow.Available = false;

            //rewrite
            using (StreamWriter sw = new StreamWriter("books.txt"))
            {
                foreach (Book book in Library.books)
                {
                    sw.WriteLine($"{book.Id};{book.Title};{book.Author};{book.Publisher};{book.ISBN};{book.PageNumber};{book.Available};{book.Genre};{book.Rarity};");
                }
            }
        }
        public void ReturnBook(int id)
        {
            //find the book with the specified ID
            Book bookToReturn = Library.books.Find(book => book.Id == id);

            //set
            bookToReturn.Available = true;

            //rewrite
            using (StreamWriter sw = new StreamWriter("books.txt"))
            {
                foreach (Book book in Library.books)
                {
                    sw.WriteLine($"{book.Id};{book.Title};{book.Author};{book.Publisher};{book.ISBN};{book.PageNumber};{book.Available};{book.Genre};{book.Rarity};");
                }
            }
        }
    }
}
