using Xunit;
using Contact_Manager.ContactManager;
using System.Collections.Generic;

namespace ContactManagerTests
{
    public class ContactsManagerTests
    {
        private Program contactManager;

        public ContactsManagerTests()
        {
            // Initialize a new instance of the contact manager before each test
            contactManager = new Program();
        }

        [Fact]
        public void AddContact_Success()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string phoneNumber = "123-456-7890";
            string type = "Friend";

            // Act
            contactManager.AddContact(firstName, lastName, phoneNumber, type);

            // Assert
            Assert.Single(contactManager.contacts);
            Assert.Equal(firstName, contactManager.contacts[0].FirstName);
            Assert.Equal(lastName, contactManager.contacts[0].LastName);
            Assert.Equal(phoneNumber, contactManager.contacts[0].PhoneNumber);
            Assert.Equal(type, contactManager.contacts[0].Type);
        }

        [Fact]
        public void RemoveContact_Success()
        {
            // Arrange
            contactManager.AddContact("John", "Doe", "123-456-7890", "Friend");

            // Act
            contactManager.RemoveContact("John", "Doe");

            // Assert
            Assert.Empty(contactManager.contacts);
        }

        [Fact]
        public void ViewAllContacts_Success()
        {
            // Arrange
            contactManager.AddContact("John", "Doe", "123-456-7890", "Friend");
            contactManager.AddContact("Alice", "Smith", "111-222-3333", "Family");
            contactManager.AddContact("Bob", "Smith", "111-222-4444", "Family");

            // Act
            contactManager.ViewAllContacts();

            // Assert
            Assert.Equal(3, contactManager.contacts.Count);
        }

        [Fact]
        public void AddContact_RejectDuplicateName()
        {
            // Arrange
            contactManager.AddContact("John", "Doe", "123-456-7890", "Friend");

            // Act
            contactManager.AddContact("Johns", "Doe", "999-999-9999", "Work");

            // Assert
            var contacts = contactManager.contacts;
            Assert.Single(contactManager.contacts); // Should still have only one contact // Should still have only one contact
        }
    }
}
