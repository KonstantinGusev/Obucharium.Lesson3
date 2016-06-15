using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyPhoneBook.Core;

namespace MyPhoneBook
{
   public class MyPhoneBookService
    {
        public void AddPerson(Person person)
        {
            var db = new MyPhoneBookContext();
            db.People.Add(person);
            db.SaveChanges();
        }

        public void UpdatePerson(int id, Person person)
        {
            var db = new MyPhoneBookContext();
            var operson = db.People.Single(p => p.Id == id);
            operson.Name = person.Name;
            operson.PhoneNumber = person.PhoneNumber;
            db.SaveChanges();
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
                db.SaveChanges();
            }
        }

        public IEnumerable<Person> GetPeople()
        {
            var db = new MyPhoneBookContext();
            return db.People;
        }

        public Person GetPerson(int id)
        {
            var db = new MyPhoneBookContext();
            var q = db.People.Include("Category").Single(p => p.Id == id);
            return q;
        }
        public IEnumerable<Category> GetCategories()
        {
            var db = new MyPhoneBookContext();
            return db.Categories.Include("People");
        }

        public void DeleteDb()
        {
            var db = new MyPhoneBookContext();
            db.Database.Delete();
        }
    }
}
