using A6_AES_CBC_Encryption.AES_CBC_EncryptDecrypt;
using A6_AES_CBC_Encryption.AES_CBC_WrongKey;
using A6_AES_CBC_Encryption.IV_Rule;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("                 🔑 Symmetric Encryption ");


//Task 6.4 : AES-CBC Encryption & Decryption
Console.WriteLine("\n\nTask 6.4 - AES-CBC Encryption and Decryption demostration");
EncryptDecrypt_AES_CBC demo1 = new EncryptDecrypt_AES_CBC();
demo1.RunEncryptDecrypt();

//Task 6.5 : Prove the IV Rule 
Console.WriteLine("\n\nTask 6.5 - Prove the IV Rule demostration");
IV_Rule demo2 = new IV_Rule();
demo2.Run_de_Rule();

//Task 6.6 : AES CBC Wrong key
Console.WriteLine("\n\nTask 6.6 - AES CBC Wrong key demostration");
AesCbcWrongKey demo3 = new AesCbcWrongKey();
demo3.Run_AES_CBC_WrongKey();