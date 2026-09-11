using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedConcepts.MiniQ3
{
    public class ContactCardDemo
    {
        public ContactCardDemo()
        {
            Demonstrate();
        }

        public void Demonstrate()
        {
            try
            {                
                ContactCard[] contacts =
                {
                    new ContactCard("Sriram","9876543210"),

                    new ContactCard("Ronnie","9876543211" ),

                    new ContactCard("Zoya", "9876543212"),

                    new ContactCard("Ananayaa", "9876543213"),

                    new ContactCard("Jerold Alvin","9876543214")
                };




                string searchName = "sRiRaM";

                Console.WriteLine( $"\nSearching for: {searchName}");

                bool found = false;

                foreach (ContactCard contact in contacts)
                {
                    if (string.Equals(
                        contact.Name,
                        searchName,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Contact found: {contact.Name}");

                        Console.WriteLine( $"Phone: {contact.PhoneNumber}");

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
