using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> BooksBorrowed { get; set; }

        public Member(int id, string name)
        {
            Id = id;
            Name = name;
            BooksBorrowed = new List<Book>();
        }
    }
}