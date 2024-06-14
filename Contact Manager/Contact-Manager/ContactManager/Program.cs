namespace Contact_Manager.ContactManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Program class to start managing contacts
            var program = new Program();
            // Call the ContactsManager method to handle contact operations
            program.ContactsManager();

            // Wait for a key press before exiting the program
            Console.ReadKey();
        }

        // Create a list to store contact objects
        public List<Contact> contacts = new List<Contact>();

        // Method to manage contacts
        public void ContactsManager()
        {
            // Add contacts with first name, last name, phone number, and type
            AddContact("Alice", "Smith", "111-222-3333", "Family");
            AddContact("Bob", "Smith", "111-222-4444", "Family");
            AddContact("Carol", "Smith", "111-222-5555", "Family");
            AddContact("David", "Brown", "222-333-4444", "Friend");
            AddContact("Eva", "Brown", "222-333-5555", "Friend");
            AddContact("Frank", "Brown", "222-333-6666", "Friend");
            AddContact("Grace", "White", "333-444-5555", "Work");
            AddContact("Henry", "White", "333-444-6666", "Work");
            AddContact("Ivy", "White", "333-444-7777", "Work");
            AddContact("John", "Wick", "111-222-8888", "Person");

            // Print the list of contacts
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of Contacts:");
            Console.ResetColor();
            ViewAllContacts();

            // Remove a contact
            RemoveContact("John", "Wick");

            // Print the updated list of contacts
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUpdated List of Contacts:");
            Console.ResetColor();
            ViewAllContacts();
        }

        // Method to add a contact
        public string AddContact(string firstName, string lastName, string phoneNumber, string type)
        {
            // Check if first name, last name, and phone number are not empty
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(phoneNumber))
            {
                // Create a new contact object
                var contact = new Contact(firstName, lastName, phoneNumber, type);
                // Check if the contact already exists
                if (!ContactExists(contact))
                {
                    // Add the contact to the list
                    contacts.Add(contact);
                    return $"Contact '{firstName} {lastName}' added successfully.";
                }
                else
                {
                    // Print a warning message if the contact already exists
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Warning: The Contact '{firstName} {lastName}' has already been added.\n");
                    Console.ResetColor();
                    return $"Warning: The Contact '{firstName} {lastName}' already exists.";

                }
            }
            else
            {
                // Print a warning message if any field is empty
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: You cannot add an empty contact!\n");
                Console.ResetColor();
                return "Warning: You cannot add an empty contact!";
            }
        }

        // Method to remove a contact
        public void RemoveContact(string firstName, string lastName)
        {
            // Find the contact to remove
            var contactToRemove = contacts.Find(c => c.FirstName == firstName && c.LastName == lastName);
            if (contactToRemove != null)
            {
                // Remove the contact from the list
                contacts.Remove(contactToRemove);
            }
            else
            {
                // Print a warning message if the contact is not found
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nWarning: No one found with the name --> {firstName} {lastName}");
                Console.ResetColor();
            }
        }

        // Method to view all contacts
        public void ViewAllContacts()
        {
            // Loop through each contact in the list
            for (int i = 0; i < contacts.Count; i++)
            {
                var contact = contacts[i];
                // Print details of each contact
                Console.WriteLine($"First Name: {contact.FirstName}, Last Name: {contact.LastName}, Phone Number: {contact.PhoneNumber}, Type: {contact.Type}");
            }
        }

        // Method to check if a contact already exists
        private bool ContactExists(Contact contact)
        {
            // Check if a contact with the same details already exists in the list
            return contacts.Exists(c => c.FirstName == contact.FirstName && c.LastName == contact.LastName && c.PhoneNumber == contact.PhoneNumber && c.Type == contact.Type);
        }
    }

    // Class to represent a contact
    public class Contact
    {
        // Properties for first name, last name, phone number, and type
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Type { get; }

        // Constructor to initialize contact details
        public Contact(string firstName, string lastName, string phoneNumber, string type)
        {
            // Assign values to contact properties
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            PhoneNumber = phoneNumber.Trim();
            Type = type.Trim();
        }
    }
}

