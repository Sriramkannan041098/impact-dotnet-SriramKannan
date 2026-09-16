using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTypeConcepts.Nullable
{
    public class DemonstrateNullableAndDiscount
    {
        public DemonstrateNullableAndDiscount() { }

        public void DemostrateMethod()
        {
            try
            {
                int? age = 27;
                long? mobileNum = null;

                //if else statement 
                if (age.HasValue)
                { Console.WriteLine($"Age: {age.HasValue}");  }
                else
                { Console.WriteLine("Age does not have a value."); }

                //Ternary operator 
                Console.WriteLine(mobileNum.HasValue ? $"{mobileNum.Value}" : "Mobile number doesn't exist.");



                double defaultDiscount = ApplyDiscount(null);

                // Passing 10 -> uses the provided 10% discount
                double providedDiscount = ApplyDiscount(50);

                Console.WriteLine($"\nDefault discount: {defaultDiscount}%");

                Console.WriteLine($"Provided discount: {providedDiscount}%");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public double ApplyDiscount(double? discount)
        {
            return discount ?? 5.0; // ?? uses 5% when discount is null. If a value is provided, that value is used.
        }
    }
}
