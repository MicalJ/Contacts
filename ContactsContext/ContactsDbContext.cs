using ContactsContext.DbModels;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsContext
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
        { }

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<CategoryPerson> CategoryPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=PREDATOR\\SQLEXPRESS;Initial Catalog=ContactsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }
}
