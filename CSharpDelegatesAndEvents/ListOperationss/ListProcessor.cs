using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDelegatesAndEvents.ListOperationss
{
    public class ListProcessor
    {
        // Constructor
        public ListProcessor()
        {
        }

        // Action<string>
        public void PrintUpperCase(string text)
        {
            Console.WriteLine(
                text.ToUpper()
            );
        }

        // Func<int, int, int>
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        // Predicate<int>
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // Process list
        public void ProcessList(
            List<int> numbers,
            Predicate<int> filter,
            Func<int, int> transform,
            Action<int> output)
        {
            foreach (int number in numbers)
            {
                // Filter
                if (filter(number))
                {
                    // Transform
                    int result = transform(number);

                    // Output
                    output(result);
                }
            }
        }
    }
}
