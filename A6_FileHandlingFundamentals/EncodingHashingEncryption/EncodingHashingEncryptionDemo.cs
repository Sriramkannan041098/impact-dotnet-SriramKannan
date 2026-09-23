using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_FileHandlingFundamentals.EncodingHashingEncryption
{
    public class EncodingHashingEncryptionDemo
    {
        public void RunDemo2()
        {           
            string originalText = "Hello C# Security";

            Console.WriteLine($"Original Text : {originalText}");

            DemonstrateBase64(originalText);

            DemonstrateSHA256(originalText);

            DemonstrateEncryption(originalText);

            /*
             * Encoding:
             * Converts data into another representation and is reversible
             * without a secret key.
             *
             * Hashing:
             * Produces a fixed-size one-way digest and is used for
             * integrity/fingerprinting.
             *
             * Encryption:
             * Converts plaintext into ciphertext and requires a key
             * to decrypt it.
             *
             * Do not use Base64 for security.
             * Do not use hashing when you need to recover the original data.
             * Do not use encryption when you only need a one-way fingerprint.
             */

            Console.WriteLine("\nEncoding, hashing and Encryption accomplished successfully..!");
        }

        // ---------------------------------------------------------
        // 1. BASE64 ENCODING
        // ---------------------------------------------------------

        private void DemonstrateBase64(string text)
        {
            Console.WriteLine("\n--- Base64 Encoding ---");

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            string encoded = Convert.ToBase64String(bytes);

            Console.WriteLine($"Encoded : {encoded}");

            // Decode Base64
            byte[] decodedBytes = Convert.FromBase64String(encoded);

            string decoded = Encoding.UTF8.GetString(decodedBytes);

            Console.WriteLine($"Decoded : {decoded}");

            Console.WriteLine(
                $"Round Trip Successful: {text == decoded}");
        }

        // ---------------------------------------------------------
        // 2. SHA-256 HASHING
        // ---------------------------------------------------------

        private void DemonstrateSHA256(string text)
        {
            Console.WriteLine("\n--- SHA-256 Hashing ---");

            byte[] inputBytes = Encoding.UTF8.GetBytes(text);

            byte[] hashBytes = SHA256.HashData(inputBytes);

            string hash = Convert.ToHexString(hashBytes);

            Console.WriteLine($"SHA-256: {hash}");

            Console.WriteLine(
                $"Hash Length: {hashBytes.Length} bytes");

            Console.WriteLine(
                "SHA-256 produces a fixed-length one-way hash.");
        }

        // ---------------------------------------------------------
        // 3. AES ENCRYPTION
        // ---------------------------------------------------------

        private void DemonstrateEncryption(string text)
        {
            Console.WriteLine("\n--- AES Encryption ---");

            using Aes aes = Aes.Create();

            aes.KeySize = 256;

            // AES automatically generates a random key and IV.
            aes.GenerateKey();
            aes.GenerateIV();

            byte[] plaintext =
                Encoding.UTF8.GetBytes(text);

            byte[] ciphertext;

            // Encrypt
            using (ICryptoTransform encryptor =
                   aes.CreateEncryptor())
            {
                ciphertext = encryptor.TransformFinalBlock(
                    plaintext,
                    0,
                    plaintext.Length);
            }

            Console.WriteLine(
                $"Ciphertext: {Convert.ToBase64String(ciphertext)}");

            // Decrypt
            byte[] decryptedBytes;

            using (ICryptoTransform decryptor =
                   aes.CreateDecryptor())
            {
                decryptedBytes = decryptor.TransformFinalBlock(
                    ciphertext,
                    0,
                    ciphertext.Length);
            }

            string decrypted =
                Encoding.UTF8.GetString(decryptedBytes);

            Console.WriteLine(
                $"Decrypted: {decrypted}");

            Console.WriteLine(
                $"Encryption Round Trip: {text == decrypted}");
        }
    }
}
