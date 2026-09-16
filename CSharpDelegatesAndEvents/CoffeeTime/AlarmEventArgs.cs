using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDelegatesAndEvents.CoffeeTime
{
    public class AlarmEventArgs : EventArgs
    {
        public DateTime AlarmTime { get; }

        // Constructor
        public AlarmEventArgs(DateTime alarmTime)
        {
            AlarmTime = alarmTime;
        }       
    }
}
