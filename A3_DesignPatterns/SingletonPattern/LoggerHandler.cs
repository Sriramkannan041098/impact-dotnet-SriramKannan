using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A3_DesignPatterns.SingletonPattern
{
    public static class LoggerHandler
    {
        private static List<Thread> threads = new List<Thread>();  
       
        public static void HandlerMethod()
        {
            // Create 5 Threads
            Console.WriteLine("\nThreads:");
            for (int i = 1; i <= 5; i++)
            {
                int threadNumber = i;

                Thread thread = new Thread(() =>
                {
                    Logger logger = Logger.Instance;
                    logger.Log($"Message from Thread {threadNumber}");
                });

                threads.Add(thread);
                thread.Start();
            }

            // Wait for all threads to finish.
            foreach (Thread thread in threads)
            {
                thread.Join();
            }



            // Create 5 Tasks
            Console.WriteLine("\nTasks:");            
            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= 5; i++)
            {
                int taskNumber = i;

                Task task = Task.Run(() =>
                {
                    Logger logger = Logger.Instance;

                    logger.Log($"Message from Task {taskNumber}");
                });

                tasks.Add(task);
            }



            // Wait for all tasks to complete.
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("\nAll Threads and Tasks completed.");
        }
    }
}


/*
 * Thread - Thread is an actual execution path managed more directly by the OS/.NET. 
 *          You explicitly create it using new Thread() and control it with methods like Start() and Join().
 * 
 * Task   - A Task represents a unit of work that is scheduled by .NET, usually on the ThreadPool.
 *          You commonly create it using Task.Run() and coordinate it using await, Wait(), or WaitAll().
 */