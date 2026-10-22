using System;
using System.Collections.Generic;
using System.Text;

namespace A6_AsymmetricAuthAndAuthorization_1.RSAConceptDemo
{
    public class AuthenticateAuthorize
    {
        public void Run_Auth()
        {

            Console.WriteLine("AUTHENTICATION");
            Console.WriteLine("Who are you? - validates the user");
            Console.WriteLine("    Example: A student logs in using username and password.");
            Console.WriteLine("    Here,The server verifies the credentials and identifies the user.");

            Console.WriteLine("\nAUTHORIZATION");
            Console.WriteLine("What are you allowed to do? - grants permission");
            Console.WriteLine("    Example: A Teacher can create marks, while a Student can only view marks.");
            Console.WriteLine("    Here,The server checks the authenticated user's role/permissions");

            Console.WriteLine("\nSESSION / COOKIE");
            Console.WriteLine("The server creates a session after successful login.");
            Console.WriteLine("The browser sends a session cookie with later requests.");
            Console.WriteLine("    Example: An ASP.NET web application maintains a user's login using a cookie.");

            Console.WriteLine("\nTOKEN");
            Console.WriteLine("A token is issued after successful authentication.");
            Console.WriteLine("The client sends the token with subsequent API requests.");
            Console.WriteLine("    Example: A client sends 'Authorization: Bearer <JWT>' to an API.");

            /*
             * Authentication:
             *     Who are you?
             *
             * Authorization:
             *     What can you do?
             *
             * Session/Cookie:
             *     Client sends a session cookie associated
             *     with server-side session state.
             *
             * Token:
             *     Client sends a token representing the
             *     authenticated identity/claims.
             */
        }
    }
}
