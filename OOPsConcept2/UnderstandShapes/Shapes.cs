using System;
using System.Collections.Generic;
using System.Text;

namespace OOPsConcept2.UnderstandShapes
{
    public abstract class Shape
    {
        // Abstract method
        // Derived classes must provide the implementation.
        public abstract double CalculateArea();

        // Concrete method
        public void DisplayArea(String description)
        {
            Console.WriteLine($"{description}: {CalculateArea()}");
        }
    }
}
