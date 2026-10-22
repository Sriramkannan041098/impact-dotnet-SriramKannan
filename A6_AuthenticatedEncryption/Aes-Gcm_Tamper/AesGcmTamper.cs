using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_AuthenticatedEncryption.Aes_Gcm_Tamper
{
    public class AesGcmTamper
    {
        private const int KeySize = 32;
        private const int NonceSize = 12;
        private const int TagSize = 16;

        public void Run_Tamper()
        {            

            string plaintext =  "This message must not be modified.";

            // 1. Generate AES-256 key
            byte[] key =  RandomNumberGenerator.GetBytes(KeySize);


            // 2. Generate fresh GCM nonce
            byte[] nonce = RandomNumberGenerator.GetBytes(NonceSize);

            byte[] plaintextBytes =  Encoding.UTF8.GetBytes(plaintext);

            byte[] ciphertext =  new byte[plaintextBytes.Length];

            byte[] tag = new byte[TagSize];


            // 3. Encrypt
            using (AesGcm aesGcm = new AesGcm(key, TagSize))
            {
                aesGcm.Encrypt(
                    nonce,
                    plaintextBytes,
                    ciphertext,
                    tag
                );
            }

            Console.WriteLine($"Original Ciphertext : {Convert.ToBase64String(ciphertext)}");

            Console.WriteLine($"Authentication Tag  : {Convert.ToBase64String(tag)}");


            // 4. Tamper with ONE ciphertext byte
            ciphertext[0] ^= 0x01;

            Console.WriteLine("\nOne byte of the ciphertext was modified.");

            Console.WriteLine($"Tampered Ciphertext  : {Convert.ToBase64String(ciphertext)}");

            // 5. Attempt decryption
            byte[] decrypted =  new byte[ciphertext.Length];
            try
            {
                using (AesGcm aesGcm = new AesGcm(key, TagSize))
                {
                    aesGcm.Decrypt(
                        nonce,
                        ciphertext,
                        tag,
                        decrypted
                    );
                }

                string decryptedText = Encoding.UTF8.GetString(decrypted);

                Console.WriteLine($"Decrypted Text : {decryptedText}");

                Console.WriteLine("WARNING         : Tampered data was accepted.");
            }
            catch (CryptographicException)
            {
                Console.WriteLine("\nCryptographicException caught.");

                Console.WriteLine("GCM rejected the modified ciphertext.");

                /*
                 * IMPORTANT:
                 *
                 * AES-GCM authenticates the ciphertext using
                 * an authentication tag.
                 *
                 * Changing even one byte causes authentication
                 * verification to fail.
                 *
                 * This is different from AES-CBC.
                 *
                 * CBC provides confidentiality but does not
                 * provide an authentication tag.
                 *
                 * Therefore, CBC alone cannot reliably detect
                 * arbitrary ciphertext tampering.
                 */
            }
        }
    }
}
