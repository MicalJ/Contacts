using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Infrastructure
{
    public class NameValidationAttribute : ValidationAttribute
    {
        public object[] Name { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            foreach (var names in Name)
            {
                if (names.ToString() == value.ToString())
                    return false;
            }

            return true;
        }
    }
}
