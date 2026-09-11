namespace CSharpAdvancedConcepts.FeatureApp
{
    public record Address
    (
        string CityName,
        string StreetName,
        int PinCode
    );      
}

/*
   Record - is a reference type that provides built-in functionality for encapsulating data. 
            It is immutable by default and is primarily used to define data models with value-based equality.

   Class - is a reference type that can contain data members (fields, properties) 
            and function members (methods, events). It supports inheritance and polymorphism.
 */