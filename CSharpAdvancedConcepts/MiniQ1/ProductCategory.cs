namespace CSharpAdvancedConcepts.MiniQ1
{

    public enum ProductCategory
    {
        Electronics,
        Clothing,
        Books,
    }

    //public class ProductCategory
    //{

    //}

    /*Since, class and enum are types they cant share similar names*/
    /*
     Type Declarations in C#:
     Class	        Defines objects with data and behavior	            class Employee { }
     Struct	        Value type for small data structures	            struct Coordinate { }
     Record	        Represents data with value-based equality           record Address(string City);
     Record Struct	Value-type version of a record	record struct       Point(int X, int Y);
     Enum	        Defines a set of named constants	                enum Days { Monday, Tuesday }
     Interface	    Defines a contract that classes/structs implement	interface IRepository { }
     Delegate	    Represents a reference to a method	delegate void   MyHandler();
     */
}
