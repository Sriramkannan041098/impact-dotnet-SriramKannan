using System;
using System.Collections.Generic;
using System.Text;

namespace A3_DesignPatterns.StockTickerObserver
{
    public interface IObserver
    {
        void Update(string stockName, decimal price);
    }
}
