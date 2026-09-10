using CSharpTypeConcepts.SecNamespaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTypeConcepts.Nullable
{
    public class DemonstrateEnumsAndFlags
    {
        public DemonstrateEnumsAndFlags()
        {
            Console.WriteLine("Demonstrate EnumsAndFlags instance created.");
        }

        public void DemostrateMethod()
        {
            try
            {
                int dayNumber;

                while (true)
                {
                    Console.Write("Enter a number between 1 and 7: ");
                    if (int.TryParse(Console.ReadLine(), out dayNumber) &&
                        dayNumber >= 1 && dayNumber <= 7)
                    {
                        break;
                    }

                    Console.WriteLine("Please enter a number between 1 and 7 only.\n");
                }

                DaysOfWeek day = (DaysOfWeek)dayNumber;
                Console.WriteLine($"Day: {day}");

                Console.WriteLine($"\nExtras - Today Date and Day");
                Console.WriteLine($"Today: {DateTime.Today:dd-MM-yyyy}");
                Console.WriteLine($"Day: {DateTime.Today.DayOfWeek}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
