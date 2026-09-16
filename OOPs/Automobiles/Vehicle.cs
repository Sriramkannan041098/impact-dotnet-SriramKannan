using System;
using System.Collections.Generic;
using System.Text;

namespace OOPs.Automobiles
{
    public class Vehicle
    {
        protected string Make;
        protected string Model;
        protected int Year;

        // Vehicle constructor
        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        // Virtual method
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {Make}, {Model}, {Year}");
        }
    }
}
