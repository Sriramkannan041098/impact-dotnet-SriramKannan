using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpModernSyntax.TupleDeconstruction
{
    public static class TupleDeconstructionDemo
    {
        

        public static void DemonstrateTuplesAndDeconstruction()
        {
            try
            {               

                // Get minimum and maximum values
                (int Min, int Max) minMax = GetMinMax(
                    new int[] { 10, 5, 25, 3, 18 }
                );

                // Deconstruct tuple into separate variables
                var (minimum, maximum) = minMax;

                Console.WriteLine($"Minimum: {minimum}");
                Console.WriteLine($"Maximum: {maximum}");

                // Employee lookup
                var employee = GetEmployee();

                // Deconstruction
                var (name, age, department) = employee;

                Console.WriteLine("\nEmployee Details:");
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"Department: {department}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static (int Min, int Max) GetMinMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            int min = numbers[0];
            int max = numbers[0];

            foreach (int number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }

                if (number > max)
                {
                    max = number;
                }
            }

            return (Min: min, Max: max);
        }

        private static (string Name, int Age, string Department) GetEmployee()
        {
            return (
                Name: "Sriram",
                Age: 25,
                Department: "Development"
            );
        }
    }
}

