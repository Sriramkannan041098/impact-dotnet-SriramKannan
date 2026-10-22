using System;
using System.Collections.Generic;
using System.Text;

namespace A6_FileHandlingFundamentals.CryptoModes
{
    public class CryptoModes
    {
        public void RunCrypto()
        {       
            Console.WriteLine(
                "ECB:" +
                "\n  Each plaintext block is encrypted independently." +
                "\n  Identical plaintext blocks produce identical ciphertext blocks, " +
                "\n  so ECB can leak patterns and should generally be avoided."
            );            


            Console.WriteLine(
                "\nCBC: " +
                "\n  Each block depends on the previous ciphertext block." +
                "\n  CBC provides confidentiality but does NOT provide authentication." +
                "\n  It requires a unique/unpredictable IV and padding."
            );
            

            Console.WriteLine(
                "\nCTR: " +
                "\n  Turns a block cipher into a stream-like cipher. " +
                "\n  It does not provide authentication by itself. " +
                "\n  The counter/nonce must never be reused with the same key."
            );


            Console.WriteLine(
                "\nGCM: " +
                "\n  Provides authenticated encryption. " +
                "\n  It provides confidentiality and integrity/authentication. " +
                "\n  It uses a nonce and authentication tag."
            );            
        }
    }
}
