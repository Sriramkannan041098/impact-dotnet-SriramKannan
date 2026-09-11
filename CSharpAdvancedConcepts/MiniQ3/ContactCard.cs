using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedConcepts.MiniQ3
{
    public struct ContactCard
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }




        public ContactCard(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
