using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class NewMember
    {
        public void signUp(int id, string name)
        {
            WriteFile writer = new WriteFile();
            Library.members.Add(new Member(id, name, new List<Book>()));
            writer.WriteUserToFile(new Member(id, name, new List<Book>()));
        }
    }
}
