using Contacts.Infrastructure;
using Xunit;

namespace Contacts.Tests.Infrastructure
{
    public class NameValidationAttributeTests
    {
        [Fact]
        public void ValidationAttribute_FormAddOrUpdateIsValid_ReturnsErrorsToClient()
        {
            //Arrange
            NameValidationAttribute attribute = new NameValidationAttribute
            {
                Name = new string[] { "chuj", "pizda" }
            };
            //Act
            var result = attribute.IsValid("chuj");
            //Assert
            Assert.False(result);
        }
    }
}
