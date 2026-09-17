using System;
using System.Collections.Generic;
using System.Text;

namespace A3_DesignPatterns.FactoryPattern
{
    public static class VehicleFactory
    {
        public static IVehicle InduceVehichle(string vehicle)
        {
            return vehicle.ToLower() switch
            {
                "car" => new Car(),
                "bike" => new Bike(),
                "truck" => new Truck(),
                _ => throw new ArgumentException($"Unknown vehicle type: {vehicle}"
                )
            };
        }
    }
}
