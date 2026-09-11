using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedConcepts.MiniQ3
{
    public class ContactCard
    {
        public ContactCard()
        {
            Console.WriteLine("ContactCard class constructor called");
            DisplayContactInfo();
        }
        public void DisplayContactInfo()
        {
            Console.WriteLine("Displaying contact information");
        }
    }
}
