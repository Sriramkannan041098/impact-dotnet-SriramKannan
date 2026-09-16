using System;
using System.Collections.Generic;
using System.Text;

namespace OOPs.SendNotfications
{
    public class Notification
    {
        // Virtual method
        public virtual void Send()
        {
            Console.WriteLine("Sending notification...");
        }
        public virtual void MessageReceive(int count) 
        {
            Console.WriteLine($"Total Message Sent : {count}\n");
        }

        /*
         * A virtual method in C# is a method in a base class
         *that can be overridden by a derived class to provide its own implementation.
         */
    }
}
