using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_AES_CBC_Encryption.AES_CBC_EncryptDecrypt
{
    public class EncryptDecrypt_AES_CBC
    {
        public void RunEncryptDecrypt()
        {           
            string plaintext = "Hello, this is a secret message.";

            Console.WriteLine($"Original Text    : {plaintext}");

            // Create AES algorithm
            using Aes aes = Aes.Create();

            // Use 256-bit AES key
            aes.KeySize = 256;
            aes.GenerateKey();

            // Generate a random IV
            aes.GenerateIV();

            Console.WriteLine($"Key Size         : {aes.Key.Length * 8} bits");

            Console.WriteLine($"IV               : {Convert.ToBase64String(aes.IV)}");

            // Encrypt
            byte[] ciphertext = Encrypt(
                plaintext,
                aes.Key,
                aes.IV);

            Console.WriteLine($"Ciphertext       : {Convert.ToBase64String(ciphertext)}");

            // Decrypt
            string decryptedText = Decrypt(
                ciphertext,
                aes.Key,
                aes.IV);

            Console.WriteLine($"Decrypted Text   : {decryptedText}");

            Console.WriteLine($"\nRound Trip Successful: " + $"{plaintext == decryptedText}");
        }

        private byte[] Encrypt( string plaintext, byte[] key, byte[] iv)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            using MemoryStream memoryStream = new MemoryStream();

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(),  CryptoStreamMode.Write))
                {
                    cryptoStream.Write(
                        plaintextBytes,
                        0,
                        plaintextBytes.Length
                    );

                    cryptoStream.FlushFinalBlock();
                }
            }

            return memoryStream.ToArray();
        }

        private string Decrypt( byte[] ciphertext, byte[] key, byte[] iv)
        {
            using MemoryStream memoryStream = new MemoryStream(ciphertext);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using CryptoStream cryptoStream = new CryptoStream(
                   memoryStream,
                   aes.CreateDecryptor(),
                   CryptoStreamMode.Read
                );

                using StreamReader reader = new StreamReader(
                   cryptoStream,
                   Encoding.UTF8
                );

                return reader.ReadToEnd();
            }
        }
    }
}
