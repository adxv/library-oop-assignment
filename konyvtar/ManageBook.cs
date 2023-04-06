using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class ManageBook
    {
        public void AddNewBook(int id, string title, string author, string publisher, long isbn, int pages, string genre, string rarity)
        {
            WriteFile writer = new WriteFile();
            Library.books.Add(new Book(id, title, author, publisher, isbn, pages, true, genre, rarity));
            writer.WriteBookToFile(new Book(id, title, author, publisher, isbn, pages, true, genre, rarity));
        }
    }
}
