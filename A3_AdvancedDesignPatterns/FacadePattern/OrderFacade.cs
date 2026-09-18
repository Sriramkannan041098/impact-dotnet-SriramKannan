namespace A3_AdvancedDesignPatterns.FacadePattern
{
    public class OrderFacade
    {
        private readonly InventoryService _inventory;
        private readonly PaymentService _payment;
        private readonly ShippingService _shipping;

        public OrderFacade(InventoryService inventory,  PaymentService payment,  ShippingService shipping)
        {
            _inventory = inventory;
            _payment = payment;
            _shipping = shipping;
        }

        public void PlaceOrder( int productId, decimal amount)
        {
            Console.WriteLine("\nPlacing order...\n");

            // Step 1 - Check inventory
            bool isAvailable =
                _inventory.CheckStock(productId);

            if (!isAvailable)
            {
                Console.WriteLine(  "Order failed: Product unavailable."   );

                return;
            }

            // Step 2 - Payment
            bool paymentSuccessful = _payment.MakePayment(amount);

            if (!paymentSuccessful)
            {
                Console.WriteLine( "Order failed: Payment unsuccessful." );

                return;
            }

            // Step 3 - Reduce inventory
            _inventory.ReduceStock(productId);

            // Step 4 - Create shipment
            _shipping.CreateShipment(productId);
            Console.WriteLine("\nOrder placed successfully." );
        }
    }
}
