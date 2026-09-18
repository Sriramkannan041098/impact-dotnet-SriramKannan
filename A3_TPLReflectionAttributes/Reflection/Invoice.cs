using System;
using System.Collections.Generic;
using System.Text;

namespace A3_TPLReflectionAttributes.Reflection
{
    public class Invoice
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public decimal Amount { get; set; }

        public Invoice()  { }

        public Invoice( int id, string customerName,  decimal amount)
        {
            Id = id;
            CustomerName = customerName;
            Amount = amount;
        }

        public void PrintInvoice()
        {
            Console.WriteLine(
                $"Invoice: {Id}, " +
                $"\nCustomer: {CustomerName}, " +
                $"\nAmount: {Amount:C}"
            );
        }

        public void CalculateTax()
        {
            decimal tax = Amount * 0.18m;

            Console.WriteLine($"\nTax: {tax:C}" );
        }
    }
}
