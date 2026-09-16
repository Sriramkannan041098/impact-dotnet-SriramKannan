namespace OOPs.Automobiles
{
    public class Bike : Vehicle
    {
        private int EngineCC;

        // Bike constructor
        public Bike(
            string make,
            string model,
            int year,
            int engineCC
        ) : base(make, model, year)
        {

            EngineCC = engineCC;
        }

        // Override
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"\nBike: {Make}, {Model}, {Year}, " +
                $"\nEngine Capacity: {EngineCC}cc"
            );
        }
    }
}
