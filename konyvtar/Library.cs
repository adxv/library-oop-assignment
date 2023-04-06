using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    public static class Library
    {
        public static List<Book> books = new List<Book>();
        public static List<Member> members = new List<Member>();

        public static void AddNewBook(int id, string title, string author, string publisher, long isbn, int pages, string genre, string rarity)
        {
            books.Add(new Book(id, title, author, publisher, isbn, pages, true, genre, rarity));
            ManageFile.WriteBookToFile(new Book(id, title, author, publisher, isbn, pages, true, genre, rarity));
        }

        public static void SignUp(int id, string name)
        {
            members.Add(new Member(id, name, new List<Book>()));
            ManageFile.WriteUserToFile(new Member(id, name, new List<Book>()));
        }

        public static int PriceCheck(int bookid)
        {
            Book bookToCheck = Library.books.Find(book => book.Id == bookid);
            int price = 0;
            if (bookToCheck.Genre.Equals("natural science") && bookToCheck.Rarity.Equals("rare"))
            {
                price = 100;
            }
            if (bookToCheck.Genre.Equals("natural science") && bookToCheck.Rarity.Equals("common"))
            {
                price = 20;
            }
            if (bookToCheck.Genre.Equals("belletristic") && bookToCheck.Rarity.Equals("rare"))
            {
                price = 50;
            }
            if (bookToCheck.Genre.Equals("belletristic") && bookToCheck.Rarity.Equals("common"))
            {
                price = 10;
            }
            if (bookToCheck.Genre.Equals("youth") && bookToCheck.Rarity.Equals("rare"))
            {
                price = 30;
            }
            if (bookToCheck.Genre.Equals("youth") && bookToCheck.Rarity.Equals("common"))
            {
                price = 10;
            }
            return price;
        }

        public static int CalculatePrice(int bookid, int days)
        {
            Book bookToCheck = Library.books.Find(book => book.Id == bookid);
            int calculatedprice = 0;

            if (days > 30)
            {
                calculatedprice = PriceCheck(bookid) * 2;
                return calculatedprice;
            }
            if (days > 40)
            {
                calculatedprice = PriceCheck(bookid) * 3;
                return calculatedprice;
            }
            if (days > 50)
            {
                calculatedprice = PriceCheck(bookid) * 4;
                return calculatedprice;
            }
            else
            {
                return calculatedprice;
            }
        }
    }
}
