namespace A3_DesignPatterns.FactoryPattern
{
    public class BikeFactory : VehicleFactoryMethod
    {
        public override IVehicle CreateVehicle()
        {
            Console.WriteLine("Manufacturing Bike....");
            return new Bike();
        }
    }
}
