using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_AES_CBC_Encryption.IV_Rule
{
    public class IV_Rule
    {
        public void Run_de_Rule()
        {
            string plaintext =  "Same plaintext encrypted twice.";

            // Create one AES key
            using Aes aes = Aes.Create();

            aes.KeySize = 256;
            aes.GenerateKey();

            byte[] key = aes.Key;

            Console.WriteLine( $"Plaintext: {plaintext}\n");

            // -------------------------------------------------
            // Encryption 1
            // -------------------------------------------------

            aes.GenerateIV();

            byte[] iv1 = aes.IV;

            byte[] ciphertext1 =
                Encrypt(
                    plaintext,
                    key,
                    iv1);

            // -------------------------------------------------
            // Encryption 2
            // -------------------------------------------------

            aes.GenerateIV();

            byte[] iv2 = aes.IV;

            byte[] ciphertext2 =
                Encrypt(
                    plaintext,
                    key,
                    iv2);

            Console.WriteLine(
                $"IV 1: {Convert.ToBase64String(iv1)}");

            Console.WriteLine(
                $"Ciphertext 1: " +
                $"{Convert.ToBase64String(ciphertext1)}\n");

            Console.WriteLine(
                $"IV 2: {Convert.ToBase64String(iv2)}");

            Console.WriteLine(
                $"Ciphertext 2: " +
                $"{Convert.ToBase64String(ciphertext2)}\n");

            bool ciphertextsAreDifferent =
                !CryptographicOperations.FixedTimeEquals(
                    ciphertext1,
                    ciphertext2);

            bool ivsAreDifferent =
                !CryptographicOperations.FixedTimeEquals(
                    iv1,
                    iv2);

            Console.WriteLine(
                $"IVs are different: {ivsAreDifferent}");

            Console.WriteLine(
                $"Ciphertexts are different: " +
                $"{ciphertextsAreDifferent}");

            // -------------------------------------------------
            // Decryption
            // -------------------------------------------------

            string decrypted1 =
                Decrypt(
                    ciphertext1,
                    key,
                    iv1);

            string decrypted2 =
                Decrypt(
                    ciphertext2,
                    key,
                    iv2);

            Console.WriteLine(
                $"\nDecrypted 1: {decrypted1}");

            Console.WriteLine(
                $"Decrypted 2: {decrypted2}");

            Console.WriteLine(
                $"\nBoth decrypt correctly: " +
                $"{plaintext == decrypted1 &&
                  plaintext == decrypted2}");
        }

        private byte[] Encrypt(
            string plaintext,
            byte[] key,
            byte[] iv)
        {
            byte[] plaintextBytes =
                Encoding.UTF8.GetBytes(plaintext);

            using MemoryStream memoryStream =
                new MemoryStream();

            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using CryptoStream cryptoStream =
                new CryptoStream(
                    memoryStream,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write);

            cryptoStream.Write(
                plaintextBytes,
                0,
                plaintextBytes.Length);

            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }

        private string Decrypt(
            byte[] ciphertext,
            byte[] key,
            byte[] iv)
        {
            using MemoryStream memoryStream =
                new MemoryStream(ciphertext);

            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using CryptoStream cryptoStream =
                new CryptoStream(
                    memoryStream,
                    aes.CreateDecryptor(),
                    CryptoStreamMode.Read);

            using StreamReader reader =
                new StreamReader(
                    cryptoStream,
                    Encoding.UTF8);

            return reader.ReadToEnd();
        }
    }
}
