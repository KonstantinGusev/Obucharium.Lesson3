using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyPhoneBook.Core;

namespace MyPhoneBook
{
    class MyPhoneBookService
    {
        public void AddPerson(Person person)
        {
            var db = new MyPhoneBookContext();
            db.People.Add(person);
        }

        public void DeletePerson(Person person)
        {
            DeletePerson(person.Id);
        }

        public void DeletePerson(int personId)
        {
            var db = new MyPhoneBookContext();
            var person = db.People.SingleOrDefault(p => p.Id == personId);
            if (person != null)
            {
                db.People.Remove(person);
            }
        }

        public IEnumerable<Person> GetPeople()
        {
            var db = new MyPhoneBookContext();
            return db.People;
        }

        public IEnumerable<Person> GetPeople(string s)
        {
            var db = new MyPhoneBookContext();
            var q = db.People.Where(p => p.Name.Contains(s));
            return q;
        }

        public IEnumerable<Category> GetCategories()
        {
            var db = new MyPhoneBookContext();
            return db.Categories;
        }

        public void DeleteDb()
        {
            var db = new MyPhoneBookContext();
            db.Database.Delete();
        }
    }
}
