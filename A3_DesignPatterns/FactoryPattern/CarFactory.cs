namespace A3_DesignPatterns.FactoryPattern
{
    public class CarFactory : VehicleFactoryMethod
    {
        public override IVehicle CreateVehicle()
        {
            Console.WriteLine("Manufacturing Car....");
            return new Car();
        }
    }
}
