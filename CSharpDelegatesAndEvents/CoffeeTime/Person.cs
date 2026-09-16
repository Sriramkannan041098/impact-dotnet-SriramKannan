using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDelegatesAndEvents.CoffeeTime
{
    public class Person
    {
        private string Name;

        // Constructor
        public Person(string name)
        {
            Name = name;
        }

        // Event handler
        public void OnAlarmRing(
            object? sender,
            AlarmEventArgs e)
        {
            Console.WriteLine(
                $"{Name} received alarm at " +
                $"{e.AlarmTime:HH:mm:ss}"
            );
        }
    }
}
