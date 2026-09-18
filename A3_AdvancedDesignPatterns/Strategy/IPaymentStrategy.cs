using System;
using System.Collections.Generic;
using System.Text;

namespace A3_AdvancedDesignPatterns.Strategy
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }
}
