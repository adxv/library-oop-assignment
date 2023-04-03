using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public long ISBN { get; set; }
        public int PageNumber { get; set; }
        public bool Available { get; set; }
        public string Genre { get; set; }
        public string Rarity { get; set; }

        public Book(int id, string title, string author, string publisher, long isbn, int pageNumber, bool available, string genre, string rarity)
        {
            Id = id;
            Title = title;
            Author = author;
            Publisher = publisher;
            ISBN = isbn;
            PageNumber = pageNumber;
            Available = available;
            Genre = genre;
            Rarity = rarity;
        }
    }
}