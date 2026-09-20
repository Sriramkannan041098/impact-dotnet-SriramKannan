using System;
using System.Collections.Generic;
using System.Text;

namespace A3_ExceptionsDisposalAsync.Asynchronous
{
    public class UserService
    {
        // Constructor
        public UserService()
        {
        }

        public async Task<string> FetchUserDataAsync(int userId)
        {
            Console.WriteLine( $"User {userId}: Start task");

            // Simulate asynchronous work
            await Task.Delay(10000);

            Console.WriteLine( $"User {userId}: End Task after awaiting for 10s");

            return $"Sanjanna completed Task:{userId}";
        }
    }
}


/*
    Sequential Execution - Tasks run one after another.
    Concurrent Execution - Multiple tasks make progress during the same period of time.
    Async means - don't block while waiting.

    Use Task<T> when you want to start an asynchronous operation 
    and postpone waiting for the result, often to run multiple operations concurrently.
 */