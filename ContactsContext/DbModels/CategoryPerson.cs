using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactsContext.DbModels
{
    public class CategoryPerson
    {
        public int CategoryPersonId { get; set; }
        public string CategoryPersonName { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
