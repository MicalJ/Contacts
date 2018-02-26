using Contacts.Infrastructure;
using ContactsContext.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class PersonRequest
    {
        [Required(ErrorMessage = "The First name field is required.")]
        [NameValidation(Name = new string[] {"pizda","chuj","kurwa"}, ErrorMessage = "Please do not type profanity!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last name field is required.")]
        [NameValidation(Name = new string[] { "pizda", "chuj", "kurwa" }, ErrorMessage = "Please do not type profanity!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Phone number field is required.")]
        [Phone(ErrorMessage = "Phone number is not valid.")]
        public string PhoneNumber { get; set; }

        public PhoneNumberType Type { get; set; }

        [EmailAddress(ErrorMessage ="Email is not valid.")]
        public string Email { get; set; }

        public int CategoryPersonId { get; set; }
    }
}
