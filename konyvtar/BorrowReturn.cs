using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class BorrowReturn
    {
        public void BorrowBook(int memberid, int bookid)
        {
            //find the book with the specified ID
            Book bookToBorrow = Library.books.Find(book => book.Id == bookid);
            Member borrowingMember = Library.members.Find(member => member.Id == member.Id);

            if (bookToBorrow.Available)
            {
                bookToBorrow.Available = false;
                borrowingMember.BooksBorrowed.Add(bookToBorrow);



                //rewrite books.txt
                using (StreamWriter sw = new StreamWriter("books.txt"))
                {
                    foreach (Book book in Library.books)
                    {
                        sw.WriteLine($"{book.Id};{book.Title};{book.Author};{book.Publisher};{book.ISBN};{book.PageNumber};{book.Available};{book.Genre};{book.Rarity};");
                    }
                }
                //rewrite members.txt
                using (StreamWriter sw = new StreamWriter("members.txt"))
                {
                    foreach (Member member in Library.members)
                    {
                        // Write the member's ID and Name to the file
                        sw.Write($"{member.Id};{member.Name};");

                        // Write the IDs of the member's borrowed books to the file
                        foreach (Book book in member.BooksBorrowed)
                        {
                            sw.Write($"{book.Id},");
                        }

                        // Write a newline character to end the line
                        sw.WriteLine();
                    }
                }
                Console.WriteLine("You have borrowed the book with the id: {0}", bookid);
            }
            else
            {
                Console.WriteLine("That book is not available at this time.");
            }

        }
        public void ReturnBook(int memberid, int bookid)
        {
            //find the book with the specified ID
            Book bookToReturn = Library.books.Find(book => book.Id == bookid);
            Member returnerMember = Library.members.Find(member => member.Id == member.Id);

            if(returnerMember.BooksBorrowed.Contains(bookToReturn)) {

            bookToReturn.Available = true;
            returnerMember.BooksBorrowed.Remove(bookToReturn);

            //rewrite books.txt
            using (StreamWriter sw = new StreamWriter("books.txt"))
            {
                foreach (Book book in Library.books)
                {
                    sw.WriteLine($"{book.Id};{book.Title};{book.Author};{book.Publisher};{book.ISBN};{book.PageNumber};{book.Available};{book.Genre};{book.Rarity};");
                }
            }
            //rewrite members.txt
            using (StreamWriter sw = new StreamWriter("members.txt"))
            {
                foreach (Member member in Library.members)
                {
                    // Write the member's ID and Name to the file
                    sw.Write($"{member.Id};{member.Name};");

                    // Write the IDs of the member's borrowed books to the file
                    foreach (Book book in member.BooksBorrowed)
                    {
                        sw.Write($"{book.Id},");
                    }

                    // Write a newline character to end the line
                    sw.WriteLine();
                }
            }
                Console.WriteLine("You have returned the book with the id: {0}", bookid);
            }
            else
            {
                Console.WriteLine("You don't have this book right now!");
            }
        }
    }
}
