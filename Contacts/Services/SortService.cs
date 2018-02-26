using Contacts.Infrastructure;
using Contacts.Interfaces;
using ContactsContext;
using ContactsContext.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Services
{
    public class SortService : ISortService
    {
        private readonly ContactsDbContext _context;
        public bool IsSortAscendingLastName { get; set; }
        public bool IsSortAscendingFirstName { get; set; }

        public SortService(ContactsDbContext context)
        {
            _context = context;
        }

        public List<Person> SortAfterFirstNameOrLastName(string choice)
        {
            IQueryable<Person> results = _context.Persons;

            if (IsSortAscendingLastName && choice=="lastName")
            {
                IsSortAscendingLastName = false;
                choice ="";
            }
            else if(!IsSortAscendingLastName && choice=="lastName")
            {
                IsSortAscendingLastName = true;
            }
            else if(IsSortAscendingFirstName && choice == "firstName")
            {
                IsSortAscendingFirstName = false;
                choice = "firstName_desc";
            }
            else
            {
                IsSortAscendingFirstName = true;
            }

            switch (choice)
            {
                case "lastName":
                    results = results.OrderBy(o => o.LastName);
                    break;
                case "firstName":
                    results = results.OrderBy(o => o.FirstName);
                    break;
                case "firstName_desc":
                    results = results.OrderByDescending(o => o.FirstName);
                    break;
                default:
                    results = results.OrderByDescending(o => o.LastName);
                    break;
            }

            return results.AsNoTracking().ToList();
        }
    }
}
