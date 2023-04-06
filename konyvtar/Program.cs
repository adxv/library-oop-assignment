using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //menu
            ManageFile reader = new ManageFile();
            reader.ReadFromFile();

            BorrowReturn br = new BorrowReturn();


            HELP:
            Console.WriteLine("_________________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Obtain a new book");
            Console.WriteLine("2. Sign up a new member");
            Console.WriteLine("3. Borrow book(s)");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. List books");
            Console.WriteLine("6. List available books");
            Console.WriteLine("7. List members");
            Console.WriteLine("8. Check what books you currently have");
            Console.WriteLine("9. Remove a book");
            Console.WriteLine("10. Information about the surcharge");
            Console.WriteLine("11. Test mode (Canvas követelmény)");
            Console.WriteLine("12. or 'exit': Exit");
            Console.WriteLine("_________________________________________");
            REPICK:
            Console.WriteLine("Please choose from the options above or type 'help' for instructions!");
            Console.WriteLine();
            string prompt = Console.ReadLine();
            
            if (prompt == "help") { goto HELP; }
            if (prompt == "exit") { return; }
            bool ok = int.TryParse(prompt, out int action);
            if (!ok || action < 1 || action > 12) { goto REPICK; }
            if (action == 12) { return; }

            //DONE
                //ASSIGN BOOKS TO MEMBERS
                //STORE MEMBERS IN FILE
                //WRITE OUT SURCHARGE WHEN CHECKING STATUS
                //WRITE OUT ACCORDING SURCHARGE WHEN RETURNING

            //newbook
            if (action == 1)
            {
                Console.WriteLine("You have chosen to obtain a new book! Please input the information in order!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Lib-ID: (MAKE SURE THAT THERE ARE NO DUPLICATES!)");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Author: ");
                string author = Console.ReadLine();
                Console.WriteLine("Publisher: ");
                string publisher = Console.ReadLine();
                Console.WriteLine("ISBN-10: ");
                long isbn = long.Parse(Console.ReadLine());
                Console.WriteLine("Number of Pages: ");
                int pages = int.Parse(Console.ReadLine());
                Console.WriteLine("Genre: (natural science OR belletristic OR youth)");
                string genre = Console.ReadLine();
                Console.WriteLine("Rarity: (rare OR common)");
                string rarity = Console.ReadLine();

                Library.AddNewBook(id, title, author, publisher, isbn, pages, genre, rarity);
                Console.WriteLine();
                Console.WriteLine("The book has been added to the database!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //signup
            if (action == 2)
            {
                Console.WriteLine("You have chosen to sign up a new member!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Please enter the Id!");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the Name!");
                string name = Console.ReadLine();
                Library.SignUp(id, name);
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //borrow book(s)
            if (action == 3) {
                Console.WriteLine("You have chosen to borrow a book!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Please enter your member ID!");
                int memberid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the ID(s) of the book(s) to borrow(up to 5 at a time)! E.g. '3' or '3,5'.");
                string[] bookids = Console.ReadLine().Split(',');
                if (bookids.Length > 5) { Console.WriteLine("You can only borrow up to 5 books at a time."); goto REPICK; }
                for (int i = 0; i < bookids.Length;i++)
                {
                    br.BorrowBook(memberid, int.Parse(bookids[i]));
                }
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }
            //return a book
            if (action == 4)
            {
                Console.WriteLine("You have chosen to return a book!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Please enter your member ID!");
                int memberid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the ID of the book to return!");
                int bookid = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the amount of days you have had this book for.");
                int days = int.Parse(Console.ReadLine());
                int surcharge = Library.CalculatePrice(bookid, days);
                if (surcharge == 0) { Console.WriteLine("You have returned this book within 30 days, so there is no charge. :)"); }
                else { Console.WriteLine("Your calculated surcharge: {0}", surcharge); }
                br.ReturnBook(memberid, bookid);
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //list all books
            if(action == 5)
            {
                Console.WriteLine("You have chosen to list all books!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                foreach (var book in Library.books)
                {
                    Console.WriteLine("id: {0}. title: {1}. author: {2}, publisher: {3}, ISBN-10: {4}, pages: {5}, available?: {6}, genre: {7}, rarity: {8}",
                    book.Id, book.Title, book.Author, book.Publisher, book.ISBN, book.PageNumber, book.Available, book.Genre, book.Rarity);
                }
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //list available books
            if (action == 6)
            {
                Console.WriteLine("You have chosen to list all AVAILABLE books!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                int avcount = 0;
                foreach (var book in Library.books)
                {
                    if(book.Available == true)
                    {
                    avcount++;
                    Console.WriteLine("id: {0}. title: {1}. author: {2}, publisher: {3}, ISBN-10: {4}, pages: {5}, available?: {6}, genre: {7}, rarity: {8}",
                    book.Id, book.Title, book.Author, book.Publisher, book.ISBN, book.PageNumber, book.Available, book.Genre, book.Rarity);
                    }
                }
                if (avcount == 0) { Console.WriteLine("There are no available books at this time. Please try again later!"); }
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //list all members
            if (action == 7)
            {
                Console.WriteLine("You have chosen to list all members!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();

                foreach (var members in Library.members)
                {
                    Console.WriteLine("id: {0}, name: {1}", members.Id, members.Name);
                }

                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //check borrowed
            if(action == 8)
            {

                Console.WriteLine("You have chosen to check what books you currently have!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Please enter your member ID!");
                int memberid = int.Parse(Console.ReadLine());
                Member member = Library.members.Find(x => x.Id == memberid);
                foreach (Book book in  member.BooksBorrowed)
                {
                    Console.WriteLine("Lib-ID: {0}, Title: {1}, Author: {2}, surcharge: {3}", book.Id, book.Title, book.Author, Library.PriceCheck(book.Id));
                }
                if(member.BooksBorrowed.Count == 0)
                {
                    Console.WriteLine("You don't have any books borrowed at this time.");
                }
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //remove a book
            if(action == 9)
            {
                Console.WriteLine("You have chosen to remove a book!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Enter the ID of the book to be removed!");
                int remove = int.Parse(Console.ReadLine());
                ManageFile.RemoveBook(remove);
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //information about surcharge
            if(action == 10) {
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("After 30 days of not returning a borrowed book, you will be charged.");
                Console.WriteLine("The exact amount depends on the genre and availability on the book,");
                Console.WriteLine("as well as the amount of days spent before returning.");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //test mode
            if(action == 11)
            {
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Enter the ID of the book to check the price of!");
                int bookid = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the amount of days!");
                int days = int.Parse(Console.ReadLine());
                int surcharge = Library.CalculatePrice(bookid, days);
                if (surcharge == 0) { Console.WriteLine("You have returned this book within 30 days, so there is no charge. :)"); }
                else { Console.WriteLine("Your calculated surcharge: {0}", surcharge); }
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //debug
            /*
            List<Book> books = new List<Book>();
            books.Add(new Book("Nineteen Eighty Four", "George Orwell", "Pub1", 4325328357342, 234, 5486));
            books.Add(new Book("The Pale Blue Dot", "Carl Sagan", "Pub2", 4625328357342, 124, 5476));

            int bn = 1;
            foreach (var book in books)
            {
                Console.WriteLine("{0}. book: {1}. author: {2}, publisher: {3}, ISBN: {4}, pages: {5}, id: {6}",
                bn, book.Title, book.Author, book.Publisher, book.ISBN, book.PageNumber, book.Id);
                bn++;
            }*/
        }
    }
}