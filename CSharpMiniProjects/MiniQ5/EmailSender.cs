using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMiniProjects.MiniQ5
{
    public class EmailSender
    {
        // Constructor
        public EmailSender()
        {
        }

        public void Send(string recipient, string message)
        {
            Console.WriteLine( $"Email sent to {recipient}: {message}" );
        }
    }
}
