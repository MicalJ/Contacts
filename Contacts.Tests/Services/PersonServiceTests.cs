using Contacts.Services;
using ContactsContext;
using ContactsContext.DbModels;
using Xunit;

namespace Contacts.Tests.Services
{
    public class PersonServiceTests
    {
        private ContactsDbContext context = new ContactsDbContext();

        [Fact]
        public void AddContact_AddPersonToDatabase_RecordAddedToDatabase()
        {
            //Arrange
            var expectedNewPerson = new Person()
            {
                CategoryPersonId = 1,
                FirstName = "Janek",
                LastName = "Jankowski",
                PhoneNumber = "789456159",
                Type = PhoneNumberType.Mobile,
                Email = "janek@gmail.com"
            };
            PersonService personService = new PersonService(context);

            //Act
            var result = personService.AddContact(expectedNewPerson);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateContact_EditContactToDatabase_RecordUpdatedToDatabase()
        {
            //Arrange
            var expectedUpdatePerson = new Person()
            {
                CategoryPersonId = 1,
                FirstName = "Antek",
                LastName = "Nowak",
                PhoneNumber = "5461235487",
                Type = PhoneNumberType.Mobile,
                Email = "nowak@gmail.com"
            };
            PersonService personService = new PersonService(context);
            //Act
            personService.AddContact(expectedUpdatePerson);
            expectedUpdatePerson.CategoryPersonId = 2; 
            var result = personService.UpdateContact(expectedUpdatePerson);
            //Assert
            Assert.True(result);
        }
    }
}