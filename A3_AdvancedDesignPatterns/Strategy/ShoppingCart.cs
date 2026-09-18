using System;
using System.Collections.Generic;
using System.Text;


namespace A3_AdvancedDesignPatterns.Strategy
{
    public class ShoppingCart
    {
        private IPaymentStrategy _paymentStrategy;
        public int CartItems { get; set; }

        public ShoppingCart(int items)
        {
            CartItems = items;
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            if(CartItems <= 0)
            {
                Console.WriteLine("Kindly pick items");
                return;
            }
            _paymentStrategy = paymentStrategy;
        }

        public void Checkout(decimal amount)
        {
            Console.WriteLine($"Checkout amount: {amount:C}");

            _paymentStrategy.Pay(amount);

            Console.WriteLine(OrderPlaced());
        }

        public string OrderPlaced()
        {
            return (CartItems > 1 ? 
                ($"Successfully {CartItems} products are ready for delivery") : 
                ($"Successfully {CartItems} product is ready for delivery"));
        }
    }
}
