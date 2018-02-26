using ContactsContext.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class PersonResponse
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberType Type { get; set; }
        public string Email { get; set; }
    
        public int CategoryPersonId { get; set; }
    }
}
