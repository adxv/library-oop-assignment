﻿using System;
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
            ReadFile reader = new ReadFile();
            WriteFile writer = new WriteFile();
            reader.ReadFromFile();

            BorrowReturn br = new BorrowReturn();

        
            Console.WriteLine("_________________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Obtain a new book");
            Console.WriteLine("2. Sign up a new member");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. List books");
            Console.WriteLine("6. List available books");
            Console.WriteLine("7. List members");
            Console.WriteLine("8. Check status of a member");
            Console.WriteLine("9. Remove a book");
            Console.WriteLine("10. Exit");
            Console.WriteLine("_________________________________________");
            REPICK:
            Console.WriteLine();
            Console.WriteLine("Please choose from the options above!");
            Console.WriteLine();
            int action = 0;
            bool ok = int.TryParse(Console.ReadLine(), out action);
            if (!ok || action < 1 || action > 10) { Console.WriteLine("You've input an incorrect number! Please choose from the options above!"); goto REPICK; }
            if (action == 10) { return; }

            //TODO:
                //MAKE ID AUTOMATIC
                //STORE MEMBERS IN FILE
                //ASSIGN BOOKS TO MEMBERS
                //WRITE OUT SURCHARGE WHEN CHECKING STATUS


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

                Library.books.Add(new Book(id, title, author, publisher, isbn, pages, true, genre, rarity));
                writer.WriteBookToFile(new Book(id, title, author, publisher, isbn, pages, true, genre, rarity));
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
                Library.members.Add(new Member(id, name));
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //borrow a book
            if (action == 3) {
                Console.WriteLine("You have chosen to borrow a book!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                Console.WriteLine("Enter the ID of the book to borrow!");
                int id = int.Parse(Console.ReadLine());
                br.BorrowBook(id);
                Console.WriteLine("You have borrowed the book with the id: {0}",id);
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
                Console.WriteLine("Enter the ID of the book to return!");
                int id = int.Parse(Console.ReadLine());
                br.ReturnBook(id);
                Console.WriteLine("You have returned the book with the id: {0}", id);
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
                    Console.WriteLine("id: {0}, name: {1}, books borrowed: {}", members.Id, members.Name);
                    //TODO
                }

                Console.WriteLine("_________________________________________");
                Console.WriteLine();
                goto REPICK;
            }

            //check status of a member
            if(action == 8)
            {
                Console.WriteLine("You have chosen to check the status of a member!");
                Console.WriteLine("_________________________________________");
                Console.WriteLine();

                //TODO

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
                writer.RemoveBook(remove);
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