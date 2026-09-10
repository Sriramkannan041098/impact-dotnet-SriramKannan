using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleA
{
    public static class Helper
    {
        public static void Greet()
        {
            try
            {
                Console.WriteLine("Hello from ModuleA Helper!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }            
        }
    }
}
