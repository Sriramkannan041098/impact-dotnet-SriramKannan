using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_AES_CBC_Encryption.AES_CBC_WrongKey
{
    public class AesCbcWrongKey
    {
        public void Run_AES_CBC_WrongKey()
        {
            string plaintext =  "Confidential CBC message.";


            // Generate correct key and IV
            using Aes aes = Aes.Create();

            aes.KeySize = 256;
            aes.GenerateKey();
            aes.GenerateIV();

            byte[] correctKey = aes.Key;
            byte[] iv = aes.IV;

            // Encrypt using correct key
            byte[] ciphertext =  Encrypt(
               plaintext,
               correctKey,
               iv
            );

            Console.WriteLine($"Original Text: {plaintext}");

            Console.WriteLine(
                $"Ciphertext: " +
                $"{Convert.ToBase64String(ciphertext)}");

            // Generate a different/wrong key
            using Aes wrongAes = Aes.Create();

            wrongAes.KeySize = 256;
            wrongAes.GenerateKey();

            byte[] wrongKey = wrongAes.Key;

            Console.WriteLine("\nAttempting decryption using wrong key...");

            try
            {
                string decrypted = Decrypt(
                  ciphertext,
                  wrongKey,
                  iv
                );

                Console.WriteLine($"Decrypted Text: {decrypted}");
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("\nCryptographicException caught.");
                Console.WriteLine($"Error: {ex.Message}");
            }

            /*
             * IMPORTANT:
             *
             * AES-CBC provides confidentiality but does not
             * authenticate the ciphertext.
             *
             * A modified ciphertext may cause a padding error,
             * but valid padding can also occur after tampering.
             *
             * Therefore, CBC alone does not provide a reliable
             * tamper/integrity signal.
             *
             * Use authenticated encryption such as AES-GCM,
             * or use CBC together with a secure MAC such as HMAC.
             */
        }

        private byte[] Encrypt( string plaintext,  byte[] key, byte[] iv)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            using MemoryStream memoryStream = new MemoryStream();

            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using CryptoStream cryptoStream = new CryptoStream(
               memoryStream,
               aes.CreateEncryptor(),
               CryptoStreamMode.Write
            );

            cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);

            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }

        private string Decrypt( byte[] ciphertext, byte[] key, byte[] iv)
        {
            using MemoryStream memoryStream = new MemoryStream(ciphertext);

            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using CryptoStream cryptoStream = new CryptoStream(
               memoryStream,
               aes.CreateDecryptor(),
               CryptoStreamMode.Read
            );

            using StreamReader reader =new StreamReader( cryptoStream,  Encoding.UTF8);

            return reader.ReadToEnd();
        }
    }
}
