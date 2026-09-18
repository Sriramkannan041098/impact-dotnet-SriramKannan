using System;
using System.Collections.Generic;
using System.Text;

namespace A3_CoreConceptsAndSorting.InterfaceAdvance
{
    public class NotificationHandler
    {
        public NotificationHandler()
        {
            // Interface example
            Console.WriteLine("Interface Example:");

            INotification notification = new EmailNotification();

            notification.Send( "Your order has been shipped." );


            // Abstract class example
            Console.WriteLine("\nAbstract Class Example:");

            ReportGenerator report =  new SalesReportGenerator(  "Monthly Sales"     );

            report.DisplayReportName();
            report.GenerateReport();


            // Static methods
            Console.WriteLine("\nStatic MathHelper:");

            Console.WriteLine( $"Factorial(5) : {MathHelper.Factorial(5)}");

            Console.WriteLine( $"IsPrime(17)  : {MathHelper.IsPrime(17)}" );

            Console.WriteLine( $"GCD(48, 18)  : {MathHelper.GCD(48, 18)}" );


            // Instance methods
            Console.WriteLine("\nInstance OrderProcessor:");

            OrderProcessor processor =  new OrderProcessor("Order Processor 1");

            processor.ProcessOrder(
                orderId: 101,
                amount: 2500
            );

            processor.CancelOrder(101);
        }
    }
}
