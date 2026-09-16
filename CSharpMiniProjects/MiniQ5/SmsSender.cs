using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMiniProjects.MiniQ5
{
    public class SmsSender
    {
        // Constructor
        public SmsSender()
        {
        }

        public void Send(string recipient,string message)
        {
            Console.WriteLine(
                $"SMS sent to {recipient}: {message}"
            );
        }
    }
}
