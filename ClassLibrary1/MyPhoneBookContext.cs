using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyPhoneBook.Core
{
    class MyPhoneBookContext
    {
        public List<Person> People { get; set; }

        public List<Category> Categories { get; set; }

    }
}
