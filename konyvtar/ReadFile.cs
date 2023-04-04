using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class ReadFile
    {
        public void ReadFromFile()
        {
            try
            {
                // Read from first file
                using (StreamReader sr = new StreamReader("books.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(';');
                        Book book = new Book(
                            int.Parse(fields[0]),
                            fields[1],
                            fields[2],
                            fields[3],
                            long.Parse(fields[4]),
                            int.Parse(fields[5]),
                            bool.Parse(fields[6]),
                            fields[7],
                            fields[8]
                        );
                        Library.books.Add(book);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: books.txt");
                Console.WriteLine(e.Message);
            }
            Dictionary<int, Book> booksDictionary = new Dictionary<int, Book>();
            foreach (Book book in Library.books)
            {
                booksDictionary.Add(book.Id, book);
            }

            try
            {
                // Read from second file
                using (StreamReader sr = new StreamReader("members.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(';');
                        int memberId = int.Parse(fields[0]);
                        string memberName = fields[1];
                        List<Book> booksBorrowed = new List<Book>();
                        if(fields.Length > 2)
                        {
                            string[] bookIds = fields[2].Split(',');
                            foreach(string bookId in bookIds)
                            {
                                if(int.TryParse(bookId, out int id))
                                {
                                    if (booksDictionary.TryGetValue(id, out Book book))
                                    {
                                        booksBorrowed.Add(book);
                                    }
                                }
                            }
                        }

                        Member member = new Member(memberId, memberName, booksBorrowed);
                        Library.members.Add(member);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: members.txt");
                Console.WriteLine(e.Message);
            }
        }
    }
}