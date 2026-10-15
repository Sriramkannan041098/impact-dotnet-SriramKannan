using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_AuthenticatedEncryption.Aes_Gcm_Encryption
{
    public class AesGcmEncryption
    {
        private const int SaltSize = 16;
        private const int NonceSize = 12;
        private const int TagSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        public void Run_AesGcmEncrypt()
        {
            
            string password =  "MyStrongPassword123!";

            string plaintext = "This message is protected using AES-GCM.";

            Console.WriteLine( $"Plaintext: {plaintext}");

            // 1. Generate random salt
            byte[] salt =  RandomNumberGenerator.GetBytes(SaltSize);


            // 2. Derive AES-256 key using PBKDF2
            byte[] key = DeriveKey(password, salt);


            // 3. Generate fresh 12-byte nonce
            byte[] nonce = RandomNumberGenerator.GetBytes(NonceSize);


            // 4. Prepare plaintext and output buffers
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            byte[] ciphertext = new byte[plaintextBytes.Length];

            byte[] tag =  new byte[TagSize];


            // 5. AES-GCM encryption
            using (AesGcm aesGcm = new AesGcm(key, TagSize))
            {
                aesGcm.Encrypt(
                    nonce,
                    plaintextBytes,
                    ciphertext,
                    tag
                );
            }

            Console.WriteLine($"\nSalt       : {Convert.ToBase64String(salt)}");

            Console.WriteLine($"Nonce      : {Convert.ToBase64String(nonce)}");

            Console.WriteLine($"Tag        : {Convert.ToBase64String(tag)}");

            Console.WriteLine($"Ciphertext : {Convert.ToBase64String(ciphertext)}");


            // 6. Store:
            // salt || nonce || tag || ciphertext
            byte[] storedData =
                Combine(
                    salt,
                    nonce,
                    tag,
                    ciphertext);

            Console.WriteLine($"\nStored Payload  : {Convert.ToBase64String(storedData)}");


            // 7. Extract stored components
            byte[] storedSalt =  storedData[..SaltSize];

            byte[] storedNonce = storedData[SaltSize..(SaltSize + NonceSize)];

            byte[] storedTag = storedData[(SaltSize + NonceSize)..(SaltSize + NonceSize + TagSize)];

            byte[] storedCiphertext = storedData[(SaltSize + NonceSize + TagSize)..];


            // 8. Derive the key again
            byte[] derivedKey =  DeriveKey(password, storedSalt);


            // 9. Decrypt and verify authentication tag
            byte[] decryptedBytes = new byte[storedCiphertext.Length];

            using (AesGcm aesGcm =  new AesGcm(derivedKey, TagSize))
            {
                aesGcm.Decrypt(
                    storedNonce,
                    storedCiphertext,
                    storedTag,
                    decryptedBytes
                );
            }

            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            Console.WriteLine($"\nDecrypted Text                   : {decryptedText}");

            Console.WriteLine($"Round Trip Successful            : {plaintext == decryptedText}");

            Console.WriteLine("Authentication Tag Verification  : SUCCESS");
        }

        private byte[] DeriveKey( string password, byte[] salt)
        {
            using Rfc2898DeriveBytes pbkdf2 =
                new Rfc2898DeriveBytes(
                    password,
                    salt,
                    Iterations,
                    HashAlgorithmName.SHA256);

            return pbkdf2.GetBytes(KeySize);
        }

        private byte[] Combine(  params byte[][] arrays)
        {
            int totalLength = 0;

            foreach (byte[] array in arrays)
            {
                totalLength += array.Length;
            }

            byte[] result =
                new byte[totalLength];

            int offset = 0;

            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(
                    array,
                    0,
                    result,
                    offset,
                    array.Length
                );

                offset += array.Length;
            }

            return result;
        }
    }
}
