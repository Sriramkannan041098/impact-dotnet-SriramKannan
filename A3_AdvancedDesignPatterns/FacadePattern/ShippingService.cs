namespace A3_AdvancedDesignPatterns.FacadePattern
{
    public class ShippingService
    {
        public void CreateShipment(int productId)
        {
            Console.WriteLine(
                $"Shipment created for Product {productId}."
            );
        }
    }
}
