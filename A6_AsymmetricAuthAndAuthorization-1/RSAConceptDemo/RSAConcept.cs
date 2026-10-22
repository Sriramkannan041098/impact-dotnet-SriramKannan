using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_AsymmetricAuthAndAuthorization_1.RSAConceptDemo
{
    public class RSAConcept
    {
        public void Run_RSAConcept()
        {
           string plaintext =  "Hello RSA!";

            Console.WriteLine($"Original Text: {plaintext}");

            // 1. Create RSA
            using RSA rsa = RSA.Create(2048);

            Console.WriteLine( $"RSA Key Size: {rsa.KeySize} bits");



            // 2. Convert plaintext to bytes
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);



            // 3. Encrypt using PUBLIC key
            //    with OAEP-SHA256
            byte[] ciphertext = rsa.Encrypt(
                    plaintextBytes,
                    RSAEncryptionPadding.OaepSHA256
            );

            Console.WriteLine( $"\nCiphertext: {Convert.ToBase64String(ciphertext)}");



            // 4. Decrypt using PRIVATE key
            byte[] decryptedBytes =  rsa.Decrypt(
                    ciphertext,
                    RSAEncryptionPadding.OaepSHA256
            );

            string decryptedText =  Encoding.UTF8.GetString(decryptedBytes);

            Console.WriteLine($"Decrypted Text: {decryptedText}");

            Console.WriteLine($"\nRound Trip Successful: {plaintext == decryptedText}");

            /*
             * RSA CONCEPTS
             *
             * Encryption:
             *   Public Key  -> Encrypt
             *   Private Key -> Decrypt
             *
             * Digital Signature:
             *   Private Key -> Sign
             *   Public Key  -> Verify
             *
             * RSA has a size limitation.
             * It cannot efficiently encrypt large files or
             * large amounts of application data directly.
             *
             * Hybrid encryption solves this:
             *
             *   RSA -> Protect a symmetric AES key
             *   AES -> Encrypt the actual data
             *
             * TLS uses asymmetric cryptography as part of
             * establishing secure communication, while
             * symmetric cryptography is used for efficient
             * bulk data protection.
             */
        }
    }
}
