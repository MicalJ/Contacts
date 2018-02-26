using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsContext.DbModels
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberType Type { get; set; }
        public string Email { get; set; }

        public virtual int CategoryPersonId { get; set; }
        public virtual CategoryPerson CategoryPerson { get; set; }
    }

    public enum PhoneNumberType
    {
        Mobile = 1,
        Home = 2,
        Work = 3,
        Other = 4
    }
}
