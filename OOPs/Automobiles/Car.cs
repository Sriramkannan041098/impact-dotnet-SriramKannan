namespace OOPs.Automobiles
{
    public class Car : Vehicle
    {
        private int NumberOfDoors;

        // Car constructor
        public Car(
            string make,
            string model,
            int year,
            int numberOfDoors
        ) : base(make, model, year)
        {
            NumberOfDoors = numberOfDoors;
        }

        // Override
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"\nCar: {Make}, {Model}, {Year}, " +
                $"\nDoors: {NumberOfDoors}"
            );
        }
    }
}
