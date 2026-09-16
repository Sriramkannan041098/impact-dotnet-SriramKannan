using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDelegatesAndEvents.MathOperation
{
    public class MathOperations
    {
        // Custom delegate
        public delegate double MathOperation(
            double a,
            double b
        );

        // Constructor
        public MathOperations()
        {
        }

        // Add method
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Subtract method
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        // Multiply method
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        // Divide method
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException(
                    "Cannot divide by zero."
                );
            }

            return a / b;
        }

        // Demonstrate custom delegate
        public void DemonstrateDelegate()
        {
            MathOperation operation;

            operation = Add;

            Console.WriteLine(
                $"Add: {operation(10, 5)}"
            );

            operation = Subtract;

            Console.WriteLine(
                $"Subtract: {operation(10, 5)}"
            );

            operation = Multiply;

            Console.WriteLine(
                $"Multiply: {operation(10, 5)}"
            );

            operation = Divide;

            Console.WriteLine(
                $"Divide: {operation(10, 5)}"
            );
        }

        // Demonstrate multicast delegate
        public void DemonstrateMulticastDelegate()
        {
            MathOperation operation;

            operation = Add;
            operation += Multiply;

            Console.WriteLine("\nMulticast Delegate:");

            operation(10, 5);
        }

        // Demonstrate Func
        public void DemonstrateFunc()
        {
            Func<double, double, double> add =
                Add;

            Func<double, double, double> multiply =
                Multiply;

            Console.WriteLine("Func:");

            Console.WriteLine(
                $"Add: {add(10, 5)}"
            );

            Console.WriteLine(
                $"Multiply: {multiply(10, 5)}"
            );
        }
    }
}
