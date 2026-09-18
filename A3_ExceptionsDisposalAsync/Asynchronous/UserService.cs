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
            Console.WriteLine( $"User {userId}: Before await");

            // Simulate asynchronous work
            await Task.Delay(3000);

            Console.WriteLine( $"User {userId}: After await");

            return $"User {userId} data";
        }
    }
}
