using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_HashingHMACAndStreaming.Stream_Encrypt
{
    public class StreamEncrypt
    {
        private const long FileSize = 100L * 1024L * 1024L;

        private const int BufferSize = 1024 * 1024; // 1 MB

        private const string OriginalFile = "large-source.bin";

        private const string EncryptedFile = "large-encrypted.bin";

        private const string DecryptedFile ="large-decrypted.bin";

        public void Run_StreamEncrypt()
        {

            // 1. Generate 100 MB file
            GenerateLargeFile();

            Console.WriteLine( $"\nOriginal file size: " +  $"{new FileInfo(OriginalFile).Length:N0} bytes");



            // 2. Generate AES key and IV
            using Aes aes = Aes.Create();

            aes.KeySize = 256;
            aes.GenerateKey();
            aes.GenerateIV();

            byte[] key = aes.Key;
            byte[] iv = aes.IV;


            // 3. Encrypt using streaming
            EncryptFile(
                OriginalFile,
                EncryptedFile,
                key,
                iv);

            Console.WriteLine("\nEncryption completed.");

            Console.WriteLine($"Encrypted file size: " +  $"{new FileInfo(EncryptedFile).Length:N0} bytes");

            // 4. Decrypt using streaming
            DecryptFile(  EncryptedFile,  DecryptedFile, key, iv);

            Console.WriteLine("\nDecryption completed.");

            Console.WriteLine($"Decrypted file size: " + $"{new FileInfo(DecryptedFile).Length:N0} bytes");


            bool identical =
                FilesAreIdentical(
                    OriginalFile,
                    DecryptedFile);

            Console.WriteLine(
                $"\nOriginal and decrypted files " +
                $"are identical: {identical}");
        }

        // -----------------------------------------------------
        // Generate a 100 MB file without loading it into memory
        // -----------------------------------------------------

        private void GenerateLargeFile()
        {
            Console.WriteLine(
                "Generating 100 MB test file...");

            byte[] buffer =
                new byte[BufferSize];

            RandomNumberGenerator.Fill(buffer);

            long bytesWritten = 0;

            using FileStream fileStream =
                new FileStream(
                    OriginalFile,
                    FileMode.Create,
                    FileAccess.Write);

            while (bytesWritten < FileSize)
            {
                long remaining =
                    FileSize - bytesWritten;

                int bytesToWrite =
                    (int)Math.Min(
                        buffer.Length,
                        remaining);

                fileStream.Write(
                    buffer,
                    0,
                    bytesToWrite);

                bytesWritten += bytesToWrite;
            }

            Console.WriteLine(
                "100 MB file generated.");
        }

        // -----------------------------------------------------
        // Encrypt using:
        //
        // FileStream -> CryptoStream
        // -----------------------------------------------------

        private void EncryptFile(
            string inputPath,
            string outputPath,
            byte[] key,
            byte[] iv)
        {
            using FileStream inputStream =
                new FileStream(
                    inputPath,
                    FileMode.Open,
                    FileAccess.Read);

            using FileStream outputStream =
                new FileStream(
                    outputPath,
                    FileMode.Create,
                    FileAccess.Write);

            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using CryptoStream cryptoStream =
                new CryptoStream(
                    outputStream,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write);

            byte[] buffer =
                new byte[BufferSize];

            int bytesRead;

            while ((bytesRead =
                inputStream.Read(
                    buffer,
                    0,
                    buffer.Length)) > 0)
            {
                cryptoStream.Write(
                    buffer,
                    0,
                    bytesRead);
            }

            // Important:
            // This writes the final padded block.
            cryptoStream.FlushFinalBlock();
        }

        // -----------------------------------------------------
        // Decrypt using:
        //
        // FileStream -> CryptoStream
        // -----------------------------------------------------

        private void DecryptFile(
            string inputPath,
            string outputPath,
            byte[] key,
            byte[] iv)
        {
            using FileStream inputStream =
                new FileStream(
                    inputPath,
                    FileMode.Open,
                    FileAccess.Read);

            using FileStream outputStream =
                new FileStream(
                    outputPath,
                    FileMode.Create,
                    FileAccess.Write);

            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using CryptoStream cryptoStream =
                new CryptoStream(
                    inputStream,
                    aes.CreateDecryptor(),
                    CryptoStreamMode.Read);

            byte[] buffer =
                new byte[BufferSize];

            int bytesRead;

            while ((bytesRead =
                cryptoStream.Read(
                    buffer,
                    0,
                    buffer.Length)) > 0)
            {
                outputStream.Write(
                    buffer,
                    0,
                    bytesRead);
            }
        }

        // -----------------------------------------------------
        // Compare two files chunk by chunk
        // -----------------------------------------------------

        private bool FilesAreIdentical(
            string firstFile,
            string secondFile)
        {
            FileInfo firstInfo =
                new FileInfo(firstFile);

            FileInfo secondInfo =
                new FileInfo(secondFile);

            if (firstInfo.Length != secondInfo.Length)
            {
                return false;
            }

            byte[] firstBuffer =
                new byte[BufferSize];

            byte[] secondBuffer =
                new byte[BufferSize];

            using FileStream firstStream =
                new FileStream(
                    firstFile,
                    FileMode.Open,
                    FileAccess.Read);

            using FileStream secondStream =
                new FileStream(
                    secondFile,
                    FileMode.Open,
                    FileAccess.Read);

            int firstBytesRead;
            int secondBytesRead;

            while ((firstBytesRead =
                firstStream.Read(
                    firstBuffer,
                    0,
                    firstBuffer.Length)) > 0)
            {
                secondBytesRead =
                    secondStream.Read(
                        secondBuffer,
                        0,
                        secondBuffer.Length);

                if (firstBytesRead != secondBytesRead)
                {
                    return false;
                }

                for (int i = 0;
                     i < firstBytesRead;
                     i++)
                {
                    if (firstBuffer[i] != secondBuffer[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
