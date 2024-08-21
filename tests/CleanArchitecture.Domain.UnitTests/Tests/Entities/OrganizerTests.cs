using FluentAssertions;
using SkillNet.Domain.Recipes.Exceptions;
using SkillNet.Domain.Recipes.Models;
using SkillNet.Domain.Recipes.Models.Memberships;

namespace SkillNet.Domain.UnitTests.Tests.Entities
{
    public class OrganizerTests
    {
        [Fact]
        public void Constructor_ShouldCorrectlyInitializeOrganizer_WhenArgumentsAreValid()
        {
            // Arrange
            var validName = "John Doe";
            var validBio = "A short bio";
            var validImageUrl = "http://example.com/image.jpg";
            var validBirthDate = new DateTime(1990, 1, 1);
            var validPhoneNumber = "+359888888888"; // Adjust based on PhoneNumber format
            var validPronouns = "They/Them"; // Adjust based on Pronouns implementation

            // Act
            var Organizer = new Organizer(validName, validBio, validImageUrl, validBirthDate, validPhoneNumber, validPronouns);

            // Assert
            Organizer.Name.Should().Be(validName);
            Organizer.Bio.Should().Be(validBio);
            Organizer.ImageUrl.Should().Be(validImageUrl);
            Organizer.BirthDate.Should().Be(validBirthDate);
            // Add assertions for PhoneNumber and Pronouns if they have public getters or other ways to validate
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidOrganizerException_ForInvalidNameLength()
        {
            // Arrange
            var invalidName = new string('a', ModelConstants.Organizer.MaxNameLength + 1); // Assuming MaxNameLength is accessible
            var validBio = "A valid bio";
            var validImageUrl = "http://example.com/image.jpg";
            var validBirthDate = new DateTime(1990, 1, 1);
            var validPhoneNumber = "123-456-7890";
            var validPronouns = "He/Him";

            // Act
            var action = () => new Organizer(invalidName, validBio, validImageUrl, validBirthDate, validPhoneNumber, validPronouns);

            // Assert
            action.Should().Throw<InvalidOrganizerException>()
                .WithMessage("*Name*");
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidOrganizerException_ForBioTooShort()
        {
            // Arrange
            var validName = "Jane Doe";
            var invalidBio = ""; // Assuming MinBioLength > 0
            var validImageUrl = "http://example.com/Organizer.jpg";
            var validBirthDate = new DateTime(1990, 1, 1);
            var validPhoneNumber = "123-456-7890";
            var validPronouns = "She/Her";

            // Act
            Action action = () => new Organizer(validName, invalidBio, validImageUrl, validBirthDate, validPhoneNumber, validPronouns);

            // Assert
            action.Should().Throw<InvalidOrganizerException>()
                .WithMessage("*Bio*");
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidOrganizerException_ForInvalidBirthDate()
        {
            // Arrange
            var validName = "John Doe";
            var validBio = "A short bio";
            var validImageUrl = "http://example.com/image.jpg";
            var invalidBirthDate = new DateTime(1800, 1, 1); // Assuming this is outside the allowed range
            var validPhoneNumber = "123-456-7890";
            var validPronouns = "He/Him";

            // Act
            var action = () => new Organizer(validName, validBio, validImageUrl, invalidBirthDate, validPhoneNumber, validPronouns);

            // Assert
            action.Should().Throw<InvalidOrganizerException>()
                .WithMessage("*BirthDate*");
        }


    }
}
