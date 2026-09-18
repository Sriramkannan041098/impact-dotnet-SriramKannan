namespace A3_CoreConceptsAndSorting.InterfaceAdvance
{
    using System;

    public static class MathHelper
    {
        public static long Factorial(int number)
        {
            long result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        public static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int GCD(int first, int second)
        {
            while (second != 0)
            {
                int remainder = first % second;

                first = second;
                second = remainder;
            }

            return Math.Abs(first);
        }
    }
}
