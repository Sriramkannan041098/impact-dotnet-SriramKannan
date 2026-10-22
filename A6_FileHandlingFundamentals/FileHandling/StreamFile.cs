using System;
using System.Collections.Generic;
using System.Text;

namespace A6_FileHandlingFundamentals.FileHandling
{
    public class StreamFile
    {
        private const int BufferSize = 4096;

        private readonly string filePath = "sample.txt";
        private readonly string copyPath = "sample_copy.txt";

        public void RunFileStreaming()
        {           
            WriteFile();
            
            ReadFile();

            AppendFile();

            CopyFile();

            VerifyFileByteByByte();

            ReadFileInChunks();

            Console.WriteLine("\nFile Streaming accompleted successfully..!");
        }

        // 1. Write to a file using FileStream
        private void WriteFile()
        {
            string content =
                "This is the original content of the file.\n" +
                "File handling is an important part of C#.\n";

            using (FileStream fileStream = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(content);

                fileStream.Write(data, 0, data.Length);
            }

            Console.WriteLine("File written successfully.");
        }

        // 2. Read a file using StreamReader
        private void ReadFile()
        {
            Console.WriteLine("\n--- Reading File ---");

            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();

                Console.WriteLine(content);
            }
        }

        // 3. Append content using StreamWriter
        private void AppendFile()
        {
            using (StreamWriter writer = new StreamWriter(
                filePath,
                append: true))
            {
                writer.WriteLine("This line was appended later.");
            }

            Console.WriteLine("Content appended successfully.");
        }

        // 4. Copy file using FileStream
        private void CopyFile()
        {
            using (FileStream sourceStream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read))
            {
                using (FileStream destinationStream = new FileStream(
                    copyPath,
                    FileMode.Create,
                    FileAccess.Write))
                {
                    sourceStream.CopyTo(destinationStream);
                }
            }

            Console.WriteLine("File copied successfully.");
        }

        // 5. Verify that original and copied files contain
        // exactly the same bytes.
        private void VerifyFileByteByByte()
        {
            bool areEqual = true;

            using (FileStream original = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read))
            {
                using (FileStream copy = new FileStream(
                    copyPath,
                    FileMode.Open,
                    FileAccess.Read))
                {
                    if (original.Length != copy.Length)
                    {
                        areEqual = false;
                    }
                    else
                    {
                        int originalByte;
                        int copyByte;

                        while ((originalByte = original.ReadByte()) != -1)
                        {
                            copyByte = copy.ReadByte();

                            if (originalByte != copyByte)
                            {
                                areEqual = false;
                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(
                $"Byte-for-byte verification: {areEqual}");
        }

        // 6. Read the file in 4 KB chunks.
        // We intentionally do NOT use ReadAllBytes().
        private void ReadFileInChunks()
        {
            Console.WriteLine("\n--- 4 KB Chunked Read ---");

            byte[] buffer = new byte[BufferSize];

            long totalBytesRead = 0;

            using (FileStream fileStream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read))
            {
                int bytesRead;

                while ((bytesRead = fileStream.Read(
                    buffer,
                    0,
                    buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;

                    Console.WriteLine(
                        $"Chunk read: {bytesRead} bytes");
                }
            }

            Console.WriteLine(
                $"Total bytes read: {totalBytesRead}");
        }
    }
}
