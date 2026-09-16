namespace OOPs.Automobiles
{
    public class ElectricCar : Vehicle
    {
        private double BatteryCapacity;
        private int NumberOfDoors;

        // ElectricCar constructor
        public ElectricCar(
            string make,
            string model,
            int year,
            double batteryCapacity,
            int door
        ) : base(make, model, year)
        {          
            BatteryCapacity = batteryCapacity;
            NumberOfDoors = door;
        }

        // Override
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"Electric Car: {Make}, {Model}, {Year}, " +
                $"\nNumber of Doors: {NumberOfDoors}" +
                $"\nBattery: {BatteryCapacity} kWh"
            );
        }
    }
}
