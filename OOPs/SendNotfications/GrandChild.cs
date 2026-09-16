using System;
using System.Collections.Generic;
using System.Text;

namespace OOPs.SendNotfications
{
    public class GrandChild : EmailNotification
    {
        public override void Send()
        {
            Console.WriteLine("Sending Email notification again from Grand Child Class...");
        }

        //public sealed override void MessageReceive(int count)
        //{
        //    base.MessageReceive(count);
        //}
        //Since, MessageReceive is sealed in EmailNotification class, so it cannot be overrided while inheritation
    }
}
