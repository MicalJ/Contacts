using ContactsContext.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public int CategoryPersonId { get; set; }
        public string CategoryPersonName { get; set; }
    }
}
