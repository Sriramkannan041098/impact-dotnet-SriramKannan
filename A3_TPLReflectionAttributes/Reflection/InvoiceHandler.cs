using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace A3_TPLReflectionAttributes.Reflection
{
    public class InvoiceHandler
    {
        public InvoiceHandler()
        {
            Type invoiceType = typeof(Invoice);


            // 1. Class Name
            Console.WriteLine($"Class Name: {invoiceType.Name}" );


            // 2. Properties
            Console.WriteLine("\nProperties:");

            PropertyInfo[] properties =  invoiceType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(
                    $"{property.Name} : " +
                    $"{property.PropertyType.Name}"
                );
            }


            // 3. Methods
            Console.WriteLine("\nMethods:");

            MethodInfo[] methods =
                invoiceType.GetMethods(
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly
                );

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(
                    method.Name
                );
            }


            // 4. Constructors
            Console.WriteLine("\nConstructors:");

            ConstructorInfo[] constructors =
                invoiceType.GetConstructors();

            foreach (ConstructorInfo constructor   in constructors)
            {
                Console.Write( "Constructor(");

                ParameterInfo[] parameters = constructor.GetParameters();

                for (int i = 0; i < parameters.Length; i++)
                {
                    ParameterInfo parameter =
                        parameters[i];

                    Console.Write(
                        $"{parameter.ParameterType.Name} " +
                        $"{parameter.Name}"
                    );

                    if (i < parameters.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine(")");
            }


            // 5. Create object using Reflection
            Console.WriteLine( "\nCreating Invoice using Reflection:" );

            Invoice? invoice = Activator.CreateInstance( invoiceType ) as Invoice;


            // 6. Set property using Reflection
            PropertyInfo? customerProperty = invoiceType.GetProperty("CustomerName");

            customerProperty?.SetValue(invoice, "Sriram");

            PropertyInfo? amountProperty = invoiceType.GetProperty("Amount" );

            amountProperty?.SetValue(invoice, 35000m);


            // 7. Read properties using Reflection
            Console.WriteLine( $"Customer : {customerProperty?.GetValue(invoice)}" );
            Console.WriteLine( $"Amount   : {amountProperty?.GetValue(invoice):C}" );
        }
    }
}
