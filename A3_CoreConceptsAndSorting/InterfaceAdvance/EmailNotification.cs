using System.Collections.Generic;
using System.Text;

namespace A3_CoreConceptsAndSorting.InterfaceAdvance
{
    using System;

    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine( $"Email sent: {message}");
        }
    }
}
