using Contacts.Infrastructure;
using Contacts.Interfaces;
using ContactsContext;
using ContactsContext.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Services
{
    public class PersonService : IPersonService
    {
        private readonly ContactsDbContext _context;

        public PersonService(ContactsDbContext context)
        {
            _context = context;
        }

        public PersonService()
        {
        }

        public List<Person> GetAllContacts()
        {
            return _context.Persons.AsNoTracking().ToList();
        }

        public Person GetByIdContact(int? contactId)
        {
            return _context.Persons.Find(contactId);
        }

        public int AddContact(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();

            return person.PersonId;
        }

        public bool UpdateContact(Person person)
        {
            if (person == null)
            {
                return false;
            }

            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public void RemoveContact(int? contactId)
        {
            var contact = GetByIdContact(contactId);

            _context.Persons.Remove(contact);
            _context.SaveChanges();
        }

        public List<Person> Searching(string search)
        {
            return _context.Persons.Where(w => search == null || w.FirstName.Contains(search) ||
                                               w.LastName.Contains(search)).ToList(); 
        }

        public List<Person> FilterCategory(int? choice)
        {
             return _context.Persons.Where(w => choice == null || w.CategoryPersonId == choice).AsNoTracking().ToList();
        }
    }
}
