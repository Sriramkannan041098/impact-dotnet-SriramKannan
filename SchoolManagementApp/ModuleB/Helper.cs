using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleB
{
    public static class Helper
    {
        public static void Greet()
        {
            try
            {
                Console.WriteLine("Hello from ModuleB Helper!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }            
        }
    }
}
