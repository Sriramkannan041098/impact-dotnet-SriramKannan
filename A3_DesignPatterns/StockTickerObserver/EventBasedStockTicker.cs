namespace A3_DesignPatterns.StockTickerObserver
{
    public class EventBasedStockTicker
    {
        public event EventHandler<StockTickerEventArgs>? PriceChanged;

        public void ChangePrice(string investorName, string stockName, float price)
        {
            Console.WriteLine($"Stock price changed: {stockName} = {price:C}");

            PriceChanged?.Invoke(
                this,
                new StockTickerEventArgs(investorName, stockName, price)
            );
        }
    }
}
