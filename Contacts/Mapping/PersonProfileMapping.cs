using AutoMapper;
using Contacts.Models;
using Contacts.ViewModels;
using ContactsContext.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Mapping
{
    public class PersonProfileMapping : Profile
    {
        public PersonProfileMapping()
        {
            CreateMap<PersonRequest, Person>();
            CreateMap<Person, PersonResponse>();
        }
    }
}
