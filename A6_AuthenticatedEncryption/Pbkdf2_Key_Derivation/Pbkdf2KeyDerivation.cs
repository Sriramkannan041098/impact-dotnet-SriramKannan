using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_AuthenticatedEncryption.Pbkdf2_Key_Derivation
{
    public class Pbkdf2KeyDerivation
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        public void Run_KeyDerivative()
        {           

            string password = "MyStrongPassword123!";

            Console.WriteLine($"Password: {password}");

            // Generate first random salt
            byte[] salt1 = RandomNumberGenerator.GetBytes(SaltSize);

            // Derive key using password + salt1
            byte[] key1 = DeriveKey(password, salt1);

            // Derive again using the SAME password + SAME salt
            byte[] key2 = DeriveKey(password, salt1);

            Console.WriteLine($"\nSalt 1  : {Convert.ToBase64String(salt1)}");

            Console.WriteLine($"Key 1   : {Convert.ToBase64String(key1)}");

            Console.WriteLine($"Key 2   : {Convert.ToBase64String(key2)}");

            bool sameKey = CryptographicOperations.FixedTimeEquals(  key1, key2);

            Console.WriteLine($"\nSame password + same salt = same key: {sameKey}");

            // Generate a different salt
            byte[] salt2 =  RandomNumberGenerator.GetBytes(SaltSize);

            byte[] key3 = DeriveKey(password, salt2);

            Console.WriteLine($"\nSalt 2  : {Convert.ToBase64String(salt2)}");

            Console.WriteLine($"Key 3   : {Convert.ToBase64String(key3)}");

            bool differentKey = !CryptographicOperations.FixedTimeEquals(key1, key3);

            Console.WriteLine($"\nDifferent salt = different key: {differentKey}");

            /*
             * Why use a salt?
             *
             * The salt ensures that the same password does not
             * always produce the same derived key.
             *
             * Why use iterations?
             *
             * PBKDF2 deliberately performs many computations.
             * This makes password guessing/brute-force attacks
             * more expensive.
             *
             * The salt is NOT a secret.
             * It can be stored alongside encrypted data.
             */
        }

        private byte[] DeriveKey(string password, byte[] salt)
        {
            using Rfc2898DeriveBytes pbkdf2 =
                new Rfc2898DeriveBytes(
                    password,
                    salt,
                    Iterations,
                    HashAlgorithmName.SHA256);

            return pbkdf2.GetBytes(KeySize);
        }
    }
}
