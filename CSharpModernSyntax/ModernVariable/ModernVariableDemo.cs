using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpModernSyntax.ModernVariable
{
    public static class ModernVariableDemo
    {
        
        public static void DemonstrateVarAndDynamic()
        {
            try
            {
                // var variable
                var number = 10;

                Console.WriteLine($"var number: {number}");

                // Uncommenting the below line causes a compile-time error
                // number = "Hello";

                Console.WriteLine(
                    "Compile Error: A variable declared using 'var' cannot be reassigned to a different type."
                );

                // dynamic variable
                dynamic value = "Hello";
                Console.WriteLine($"dynamic value: {value}, Type: {value.GetType()}");

                value = 100;
                Console.WriteLine($"dynamic value: {value}, Type: {value.GetType()}");

                value = true;
                Console.WriteLine($"dynamic value: {value}, Type: {value.GetType()}");

                // Dynamic parameter method
                Console.WriteLine("\nCalling AddDynamic with integers:");
                Console.WriteLine(AddDynamic(10, 20));

                Console.WriteLine("\nCalling AddDynamic with strings:");
                Console.WriteLine(AddDynamic("Hello ", "World"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static dynamic AddDynamic(dynamic first, dynamic second)
        {
            return first + second;
        }
    }
}
