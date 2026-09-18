namespace A3_AdvancedDesignPatterns.FacadePattern
{
    public class PaymentService
    {
        public bool MakePayment(decimal amount)
        {
            Console.WriteLine( $"Payment processed: {amount:C}");

            return true;
        }
    }
}
