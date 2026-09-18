namespace A3_DesignPatterns.StockTickerObserver
{
    public class Investor : IObserver
    {
        public string Name { get; }

        public Investor(string name)
        {
            Name = name;
        }

        public void Update(string stockName, decimal price)
        {
            Console.WriteLine($"{Name} received update: {stockName} price = {price:C}");
        }
    }
}
