using A6_AsymmetricAuthAndAuthorization_1.RSAConceptDemo;
using System.Security.Cryptography;


//Task 6.13 - RSA Encryption
Console.WriteLine("\nTask 6.13 - RSA Encryption");
RSAConcept demo1 = new RSAConcept();
demo1.Run_RSAConcept();


//Task 6.14 - Authentication & Authorization
Console.WriteLine("\n\nTask 6.14 - Authentication & Authorization");
AuthenticateAuthorize demo2 = new AuthenticateAuthorize();
demo2.Run_Auth();