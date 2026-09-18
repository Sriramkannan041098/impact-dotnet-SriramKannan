using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleA
{
    public static class Helper
    {
        public static string? studentName;

        
        public static void Greet()
        {
            try
            {
                Console.WriteLine($"Hello {studentName} from ModuleA Helper!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }            
        }
    }
}
