using Contacts.Models;
using Contacts.ViewModels;
using ContactsContext.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Interfaces
{
    public interface IPersonService
    {
        List<Person> GetAllContacts();

        Person GetByIdContact(int? contactId);

        int AddContact(Person person);

        bool UpdateContact(Person person);

        void RemoveContact(int? contactId);

        List<Person> Searching(string search);

        List<Person> FilterCategory(int? choice);
    }
}
