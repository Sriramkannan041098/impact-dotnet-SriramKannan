using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace A6_HashingHMACAndStreaming.DigestComparison
{
    public class Digest_Comparison
    {
        public void Run_DigestComp()
        {            

            string message =
                "Sensitive data for digest comparison.";

            byte[] data =
                Encoding.UTF8.GetBytes(message);

            byte[] digest1 =
                SHA256.HashData(data);

            byte[] digest2 =
                SHA256.HashData(data);

            Console.WriteLine(
                $"Digest 1: {Convert.ToHexString(digest1)}");

            Console.WriteLine(
                $"Digest 2: {Convert.ToHexString(digest2)}");

            // -------------------------------------------------
            // Recommended cryptographic comparison
            // -------------------------------------------------

            bool areEqual =
                CryptographicOperations.FixedTimeEquals(
                    digest1,
                    digest2);

            Console.WriteLine(
                $"\nFixedTimeEquals result: {areEqual}");

            // -------------------------------------------------
            // Demonstrate changed digest
            // -------------------------------------------------

            byte[] modifiedData =
                Encoding.UTF8.GetBytes(
                    "Modified sensitive data.");

            byte[] modifiedDigest =
                SHA256.HashData(modifiedData);

            bool modifiedComparison =
                CryptographicOperations.FixedTimeEquals(
                    digest1,
                    modifiedDigest);

            Console.WriteLine(
                $"Modified digest matches: " +
                $"{modifiedComparison}");

            /*
             * IMPORTANT:
             *
             * CryptographicOperations.FixedTimeEquals()
             * is designed for comparing sensitive byte values
             * such as hashes, HMACs and authentication tags.
             *
             * Ordinary comparison approaches may stop as soon
             * as a mismatch is found.
             *
             * If the amount of work depends on how many initial
             * bytes match, an attacker may potentially infer
             * information from timing differences.
             *
             * FixedTimeEquals performs the comparison in a way
             * designed to avoid leaking information through this
             * kind of timing difference.
             *
             * NOTE:
             * For byte arrays, == compares references rather than
             * the contents. SequenceEqual compares contents but
             * may short-circuit on the first mismatch. For
             * cryptographic values, use FixedTimeEquals.
             */
        }
    }
}
