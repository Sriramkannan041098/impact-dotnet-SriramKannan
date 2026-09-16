using CSharpTypeConcepts.Others;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTypeConcepts.EnumsFlags
{
    public class DemonstrateEnumsAndFlags
    {
        public DemonstrateEnumsAndFlags()
        {
            
        }

        public void DemostrateMethod()
        {
            try
            {
                int dayNumber;

                while (true)
                {
                    Console.Write("Enter a number between 1 to 7: ");
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


                Console.WriteLine("\nPermissions:");
                //FilePermission permissions = FilePermission.None | FilePermission.Read | FilePermission.Write | FilePermission.Execute;
                //FilePermission permissions = FilePermission.None;

                FilePermission permissions = FilePermission.Read | FilePermission.Write;
                Console.WriteLine( $"Combined Permissions: {permissions}" );
                /*
                 * Since None = 0 it's not considered as meaningful flag
                 * So , when you combine None with other flags, it doesn't change the result.
                 * But if you print only None, result displays None.
                 */

                bool hasReadPermission = (permissions & FilePermission.Read) == FilePermission.Read; 
                Console.WriteLine( $"Has Read Permission: {hasReadPermission}" ); 
                
                bool hasExecutePermission = (permissions & FilePermission.Execute) == FilePermission.Execute; 
                Console.WriteLine( $"Has Execute Permission: {hasExecutePermission}" );

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

/*
    enum - it is a named related constant values and used when only one value should be selected at a time.

    flag - it is a named set of related constant values and used when multiple values can be combined together using bitwise operations.
           [Flags] that allows combining multiple values using bitwise operations (|)

    
 */


