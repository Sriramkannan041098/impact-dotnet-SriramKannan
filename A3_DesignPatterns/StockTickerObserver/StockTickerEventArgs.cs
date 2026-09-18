namespace A3_DesignPatterns.StockTickerObserver
{
    public class StockTickerEventArgs : EventArgs
    {
        public string StockName { get; }
        public float Price { get; }
        public string InvestorName { get; }

        public StockTickerEventArgs(string invName, string stockName, float price)
        {
            StockName = stockName;
            Price = price;
            InvestorName = invName;
        }
    }
}
