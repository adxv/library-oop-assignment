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

            try
            {
                // Read from second file
                using (StreamReader sr = new StreamReader("members.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
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