using A6_HashingHMACAndStreaming.DigestComparison;
using A6_HashingHMACAndStreaming.FileHash_Hmac;
using A6_HashingHMACAndStreaming.Stream_Encrypt;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("       🫣 Hashing HMAC and Streaming ");

//Task 6.10 — SHA256, SHA512 & HMACSHA256
Console.WriteLine("\n\nTask 6.10 — SHA256, SHA512 & HMACSHA256");
FileHashHmac demo1 = new FileHashHmac();
demo1.Run_Hmac_Hashing();

//Task 6.11 Constant-Time Digest Comparison 
Console.WriteLine("\n\nTask 6.11 Constant-Time Digest Comparison ");
Digest_Comparison demo2 = new Digest_Comparison();
demo2.Run_DigestComp();


//Task 6.12 — Stream-Encrypt a 100+ MB File
Console.WriteLine("\n\nTask 6.12 — Stream-Encrypt a 100+ MB File");
StreamEncrypt demo3 = new StreamEncrypt();
demo3.Run_StreamEncrypt();

