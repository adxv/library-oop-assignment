using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class Price
    {
        public int priceCheck(int bookid)
        {
            Book bookToCheck = Library.books.Find(book => book.Id == bookid);
            int price = 0;
            if (bookToCheck.Genre.Equals("natural science") && bookToCheck.Rarity.Equals("rare")) {
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
    }
}
