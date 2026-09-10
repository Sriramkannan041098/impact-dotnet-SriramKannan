using CSharpTypeConcepts.EnumFlags;
using CSharpTypeConcepts.Nullable;
using CSharpTypeConcepts.TypeConversions;
using CSharpTypeConcepts.ValueRefType;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("C# Type Concepts");

        //Task 1.9
        Console.WriteLine("\nTask 1.9: Demonstrate Value and Reference Types");
        DemonstrateValueAndReferenceTypes demo1 = new DemonstrateValueAndReferenceTypes(15, 6);
        demo1.DemostrateMethod();

        //Task 1.10
        Console.WriteLine("\n\nTask 1.10: Demonstrate Enums and Flags");
        DemonstrateEnumsAndFlags demo2 = new DemonstrateEnumsAndFlags();
        demo2.DemostrateMethod();

        //Task 1.11
        Console.WriteLine("\n\nTask 1.11: Demonstrate Nullable and Discount");
        DemonstrateNullableAndDiscount demo3 = new DemonstrateNullableAndDiscount();
        demo3.DemostrateMethod();

        //Task 1.12
        Console.WriteLine("\n\nTask 1.12: Demonstrate Type Conversions");
        DemonstrateTypeConversions demo4 = new DemonstrateTypeConversions();
        demo4.DemostrateMethod();

    }
}
