using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpModernSyntax.PatternMatching
{
    public static class PatternMatchingDemo
    {
        
        public static void DemonstratePatternMatching()
        {
            try
            {
                

                // Object pattern matching
                Console.WriteLine("Object Pattern Matching:");

                HandleObject(100);
                HandleObject("Hello");
                HandleObject(25.5);
                HandleObject(null);

                // Grade calculation using switch expression
                Console.WriteLine("\nGrade Calculator:");

                Console.WriteLine($"Score 95: {CalculateGrade(95)}");
                Console.WriteLine($"Score 82: {CalculateGrade(82)}");
                Console.WriteLine($"Score 72: {CalculateGrade(72)}");
                Console.WriteLine($"Score 60: {CalculateGrade(60)}");
                Console.WriteLine($"Score 40: {CalculateGrade(40)}");

                // Property pattern
                Console.WriteLine("\nOrder Discount:");

                Order order1 = new Order
                {
                    Status = "Completed",
                    Amount = 1500
                };

                Order order2 = new Order
                {
                    Status = "Pending",
                    Amount = 1500
                };

                Order order3 = new Order
                {
                    Status = "Completed",
                    Amount = 500
                };

                Console.WriteLine($"Order 1 Discount: {CalculateDiscount(order1)}%");
                Console.WriteLine($"Order 2 Discount: {CalculateDiscount(order2)}%");
                Console.WriteLine($"Order 3 Discount: {CalculateDiscount(order3)}%");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void HandleObject(object value)
        {
            switch (value)
            {
                case int number:
                    Console.WriteLine($"Integer branch: {number}");
                    break;

                case string text:
                    Console.WriteLine($"String branch: {text}");
                    break;

                case double decimalNumber:
                    Console.WriteLine($"Double branch: {decimalNumber}");
                    break;

                case null:
                    Console.WriteLine("Null branch");
                    break;

                default:
                    Console.WriteLine("Unknown type branch");
                    break;
            }
        }

        private static string CalculateGrade(int score)
        {
            return score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
        }

        private static int CalculateDiscount(Order order)
        {
            return order switch
            {
                { Status: "Completed", Amount: >= 1000 } => 20,
                { Status: "Completed", Amount: >= 500 } => 10,
                { Status: "Completed" } => 5,
                _ => 0
            };
        }
    }

    public class Order
    {
        public string Status { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}
