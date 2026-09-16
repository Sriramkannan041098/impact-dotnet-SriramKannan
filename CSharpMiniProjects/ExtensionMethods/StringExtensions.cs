using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMiniProjects.ExtensionMethods
{
    public static class StringExtensions
    {
        
        // Extension method for string
        public static string ToTitleCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            string[] words =
                value.ToLower().Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] =
                        char.ToUpper(words[i][0]) +
                        words[i].Substring(1);
                }
            }

            return string.Join(" ", words);
        }
    }
}
