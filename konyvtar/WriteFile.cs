using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class WriteFile
    {
        public void WriteBookToFile(Book book)
        {
            using (StreamWriter sw = new StreamWriter("books.txt", true))
            {
                sw.WriteLine($"{book.Id};{book.Title};{book.Author};{book.Publisher};{book.ISBN};{book.PageNumber};{book.Available};{book.Genre};{book.Rarity};");
            }
        }
        public void RemoveBook(int id)
        {
            // Remove the book from the list
            Book bookToRemove = Library.books.Find(book => book.Id == id);
            Library.books.Remove(bookToRemove);

            // Rewrite the file without the removed book
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
