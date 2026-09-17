using System;
using System.Collections.Generic;
using System.Text;

namespace A3_DesignPatterns.FactoryPattern
{
    public class Truck :IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving Truck");
        }
    }
}
