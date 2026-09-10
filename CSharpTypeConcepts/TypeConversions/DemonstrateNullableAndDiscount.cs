using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTypeConcepts.TypeConversions
{
    public class DemonstrateNullableAndDiscount
    {
        
        public DemonstrateNullableAndDiscount()
        {
            
        }

        public void DemostrateMethod()
        {
            try
            {
                int? age = null;

                if (age.HasValue)
                {
                    Console.WriteLine($"Age: {age.Value}");
                }
                else
                {
                    Console.WriteLine("Age does not have a value.");
                }

                double defaultDiscount = ApplyDiscount(null);

                // Passing 10 -> uses the provided 10% discount
                double providedDiscount = ApplyDiscount(50);

                Console.WriteLine(
                    $"Default discount: {defaultDiscount}%");

                Console.WriteLine(
                    $"Provided discount: {providedDiscount}%");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public double ApplyDiscount(double? discount)
        {
            // ?? uses 5% when discount is null.
            // If a value is provided, that value is used.
            return discount ?? 5.0;
        }
    }
}
