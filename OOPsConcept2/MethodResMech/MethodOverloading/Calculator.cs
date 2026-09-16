using System;
using System.Collections.Generic;
using System.Text;

namespace OOPsConcept2.MethodResMech.MethodOverloading
{
    public class Calculator
    {
        // Add two integers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Add two doubles
        public double Add(double a, double b)
        {
            return a + b;
        }



        // Add three integers
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }



        // Add multiple integers
        public int Add(params int[] numbers)
        {
            int result = 0;

            foreach (int number in numbers)
            {
                result += number;
            }
            return result;
        }

    }
}
