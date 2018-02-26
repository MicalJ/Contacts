using ContactsContext.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Interfaces
{
    public interface ISortService
    {
        List<Person> SortAfterFirstNameOrLastName(string choice);
    }
}
