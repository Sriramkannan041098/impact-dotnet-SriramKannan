using System;
using System.Collections.Generic;
using System.Text;

namespace A3_AdvancedDesignPatterns.Strategy
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using Credit Card.");
        }
    }
}
