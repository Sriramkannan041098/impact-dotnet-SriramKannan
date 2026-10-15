using A6_AuthenticatedEncryption.Aes_Gcm_Encryption;
using A6_AuthenticatedEncryption.Aes_Gcm_Tamper;
using A6_AuthenticatedEncryption.Pbkdf2_Key_Derivation;



Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("       🔐 Authenticated Encryption & Key Derivation ");

//Task 6.7 - PBKDF2 Key Derivation
Console.WriteLine("\n\nTask 6.7 - PBKDF2 Key Derivation");
Pbkdf2KeyDerivation demo1 = new Pbkdf2KeyDerivation();
demo1.Run_KeyDerivative();


//Task 6.8 - AES-GCM Authenticated Encryption
Console.WriteLine("\n\nTask 6.8 - AES-GCM Authenticated Encryption");
AesGcmEncryption demo2 = new AesGcmEncryption();
demo2.Run_AesGcmEncrypt();


//Task 6.9 - AES-GCM Tamper Detection
Console.WriteLine("\n\nTask 6.9 - AES-GCM Tamper Detection");
AesGcmTamper demo3 = new AesGcmTamper();
demo3.Run_Tamper();