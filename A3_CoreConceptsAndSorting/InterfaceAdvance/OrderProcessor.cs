namespace A3_CoreConceptsAndSorting.InterfaceAdvance
{
    using System;

    public class OrderProcessor
    {
        private string _processorName;

        public OrderProcessor(string processorName)
        {
            _processorName = processorName;
        }

        public void ProcessOrder(
            int orderId,
            decimal amount)
        {
            Console.WriteLine(
                $"Processor: {_processorName}"
            );

            Console.WriteLine(
                $"Processing Order: {orderId}"
            );

            Console.WriteLine(
                $"Amount: {amount:C}"
            );
        }

        public void CancelOrder(int orderId)
        {
            Console.WriteLine(
                $"Order {orderId} cancelled by {_processorName}."
            );
        }
    }


}
