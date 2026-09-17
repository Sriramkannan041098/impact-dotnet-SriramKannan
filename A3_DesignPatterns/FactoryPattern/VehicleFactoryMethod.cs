namespace A3_DesignPatterns.FactoryPattern
{
    public abstract class VehicleFactoryMethod
    {
        // Factory Method
        public abstract IVehicle CreateVehicle();

        public void StartVehicle()
        {
            IVehicle vehicle = CreateVehicle();

            vehicle.Drive();
        }
    }
}
