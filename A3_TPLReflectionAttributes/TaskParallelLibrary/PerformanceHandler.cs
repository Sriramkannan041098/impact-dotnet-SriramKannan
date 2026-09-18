using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace A3_TPLReflectionAttributes.TaskParallelLibrary
{
    public class PerformanceHandler
    {
        public PerformanceHandler()
        {
            Console.WriteLine("Performance check on progress...");

            int operationCount = 100;

            OperationService service =  new OperationService();

            List<int> operations = new List<int>();

            for (int i = 1; i <= operationCount; i++)
            {
                operations.Add(i);
            }



            // 1. Sequential foreach
            Stopwatch stopwatch =  Stopwatch.StartNew();

            foreach (int operation in operations)
            {
                service.PerformOperation(operation);
            }

            stopwatch.Stop();

            Console.WriteLine( $"Sequential foreach: {stopwatch.ElapsedMilliseconds} ms");



            // 2. Thread
            stopwatch.Restart();

            List<Thread> threads =  new List<Thread>();

            foreach (int operation in operations)
            {
                int operationNumber = operation;

                Thread thread = new Thread(() => { service.PerformOperation(operationNumber); });

                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            stopwatch.Stop();

            Console.WriteLine( $"Thread: {stopwatch.ElapsedMilliseconds} ms" );




            // 3. Task.Run
            stopwatch.Restart();

            List<Task> tasks =  new List<Task>();

            foreach (int operation in operations)
            {
                int operationNumber = operation;

                Task task = Task.Run(() => { service.PerformOperation(operationNumber);  });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            stopwatch.Stop();

            Console.WriteLine( $"Task.Run: {stopwatch.ElapsedMilliseconds} ms" );



            // 4. Parallel.ForEach
            stopwatch.Restart();

            Parallel.ForEach(
                operations,
                operation =>  { service.PerformOperation(operation); } 
            );

            stopwatch.Stop();



            Console.WriteLine( $"Parallel.ForEach: {stopwatch.ElapsedMilliseconds} ms" );
        }
    }
}
