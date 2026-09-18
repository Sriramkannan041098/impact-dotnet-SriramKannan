namespace A3_DesignPatterns.StockTickerObserver
{
    public class StockTicker
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void ChangePrice(string stockName, decimal price)
        {
            Console.WriteLine($"Stock price changed: {stockName} = {price:C}");

            NotifyObservers(stockName, price);
        }

        private void NotifyObservers(string stockName, decimal price)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(stockName, price);
            }
        }
    }
}
