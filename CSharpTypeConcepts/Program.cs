

using CSharpTypeConcepts.EnumFlags;
using CSharpTypeConcepts.Nullable;
using CSharpTypeConcepts.TypeConversions;
using CSharpTypeConcepts.ValueRefType;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("C# Type Concepts\n");

        //Task 1.9
        DemonstrateValueAndReferenceTypes demonstrateValueAndReferenceTypes = new DemonstrateValueAndReferenceTypes();

        //Task 1.10
        DemonstrateEnumsAndFlags demonstrateEnumsAndFlags = new DemonstrateEnumsAndFlags();

        //Task 1.11
        DemonstrateNullableAndDiscount demonstrateNullableAndDiscount = new DemonstrateNullableAndDiscount();

        //Task 1.12
        DemonstrateTypeConversions demonstrateTypeConversions = new DemonstrateTypeConversions();

    }
}
