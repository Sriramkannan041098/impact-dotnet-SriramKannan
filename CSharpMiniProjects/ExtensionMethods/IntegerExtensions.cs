namespace CSharpMiniProjects.ExtensionMethods
{
    public static class IntegerExtensions
    {
        private static readonly string[] Ones = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};

        private static readonly string[] Teens = {"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

        private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        // Extension method for int
        public static string ToWords(this int number)
        {
            //try
            //{
                if (number < 0 || number > 999)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(number),
                        "Number must be between 0 and 999."
                    );
                }

                if (number < 10)
                {
                    return Ones[number];
                }

                if (number < 20)
                {
                    return Teens[number - 10];
                }

                if (number < 100)
                {
                    int tens = number / 10;  // 89/10 = 8.9
                    int ones = number % 10;  // 89%10 = 9

                    if (ones == 0)
                    {
                        return Tens[tens];
                    }

                    return $"{Tens[tens]}-{Ones[ones]}"; //if 89 then eighty nine
                }

                int hundreds = number / 100;
                int remainder = number % 100;

                if (remainder == 0)
                {
                    return $"{Ones[hundreds]} Hundred";
                }

                return $"{Ones[hundreds]} Hundred {remainder.ToWords()}";
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}            
        }
    }
}
