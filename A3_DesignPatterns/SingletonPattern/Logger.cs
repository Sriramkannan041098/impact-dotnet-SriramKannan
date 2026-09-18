using System;
using System.Collections.Generic;
using System.Text;

namespace A3_DesignPatterns.SingletonPattern
{
    public sealed class Logger
    {        
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger()); // Logger is a Singleton

        
        public static Logger Instance => _instance.Value;   // Public access point to the single Logger instance's value.

        // Private constructor prevents creating Logger using new.
        //private Logger() { }        

        public void Log(string message)
        {
            Console.WriteLine(
                $"[{Thread.CurrentThread.ManagedThreadId}] " +
                $"HashCode: {GetHashCode()} - {message}"
            );
        }

        //public void Testing()
        //{
        //    Console.WriteLine("testing");
        //}
    }
}


// Lazy<T> creates the instance only when it is accessed.
// Lazy<T> is thread-safe by default.


/*
  Thread.CurrentThread.ManagedThreadId -.NET/OS creates a thread and assigns during RunTime
  GetHashCode - comes from the base object class in C#.
*/


/* output:-
       [14] HashCode: 1997173 - Message from Thread 3
         ↓              ↓                ↓
      ThreadID  Logger Obj Hashcode   Message
 */
