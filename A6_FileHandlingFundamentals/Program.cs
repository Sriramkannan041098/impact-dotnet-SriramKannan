using A6_FileHandlingFundamentals.EncodingHashingEncryption;
using A6_FileHandlingFundamentals.FileHandling;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("                 🗃️ File Handling and Fundamentals ");

//Task 6.1 :- Streaming File
Console.WriteLine("\n\nTask 6.1 : File Streaming demostration");
StreamFile demo1 = new StreamFile();
demo1.RunFileStreaming();

//Task 6.2 :- Encoding, Hashing & Encryption demostration
Console.WriteLine("\n\nTask 6.2 : Encoding, hashing and Encryption demostration");
EncodingHashingEncryptionDemo demo2 =  new EncodingHashingEncryptionDemo();
demo2.RunDemo2();



