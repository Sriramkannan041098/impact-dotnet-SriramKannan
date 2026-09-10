using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTypeConcepts.ValueRefType
{
    public class DemonstrateTypeConversions
    {
        public DemonstrateTypeConversions()
        {
            //Console.WriteLine("Demonstrate TypeConversions instance created.");
        }

        public void DemostrateMethod()
        {
            try
            {
                Console.WriteLine("Implicit Type Conversions:");
                int intValue = 100;
                long longValue = intValue;
                float floatValue = longValue;
                double doubleValue = floatValue;

                Console.WriteLine($"int: {intValue}");
                Console.WriteLine($"long: {longValue}");
                Console.WriteLine($"float: {floatValue}");
                Console.WriteLine($"double: {doubleValue}");
                /*
                   Implicit conversions happens when values of low data type 
                   are converted to higher data type automatically.
                */


                double originalValue = 25.75;
                int convertedValue = (int)originalValue;

                Console.WriteLine("\nExplicit Type Conversions:");
                Console.WriteLine($"Original double: {originalValue}");
                Console.WriteLine($"Converted int: {convertedValue}");

                /*
                   Explicit conversions happens when values of Higher data type 
                   are converted to Lower data type manually.
                */

                Console.WriteLine("\nConvert String to Int:");
                string newNumber = "123";
                int parsedNumber = int.Parse(newNumber);  //int.Parse is used to convert string to int
                Console.WriteLine($"Parsed int: {parsedNumber}");

                Console.WriteLine("\nConvert String to Int using TryParse:");
                string userInput = "345";

                if (int.TryParse(userInput, out int parsedNum))
                {
                    Console.WriteLine($"TryParse: {parsedNum}");
                }
                else
                {
                    Console.WriteLine("TryParse: Invalid number.");
                }


                Console.WriteLine("\nConvert String to Int using ToInt32:");
                string numberText = "345";
                int convertedNumber = Convert.ToInt32(numberText);

                Console.WriteLine($"Convert.ToInt32: {convertedNumber}");


               /*
                 If the value is string rather than number then ToInt32 will throw an exception
                 Whereas, if the value is string rather than number then TryParse will return false and not throw an exception.
               */
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
