using OOPsConcept2.MethodResMech.Operators;
using OOPsConcept2.UnderstandingInterface;
using OOPsConcept2.UnderstandShapes;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Advance OOPs concept and others ");

        //Task 2.4 - Abstract Class
        Console.WriteLine("\n\nTask 2.4 - Abstract Class Demostration");
        Circle circle = new Circle(5);
        circle.DisplayArea("Area of Circle");

        Rectangle rectangle = new Rectangle(10, 5);        
        rectangle.DisplayArea("Area of Rectangle");

        //Shape sp = new Shape();

        /*
         * Though it is a Base Class it cannot be initiated directly
         * It can only be implemented because this is an Abstract Class
         */


        //Task 2.5 - Interface understanding
        Console.WriteLine("\n\nTask 2.5 - Interface Demostration");
        DrawableShape shape = new DrawableShape(10, 5);

        Console.WriteLine($"Area: {shape.CalculateArea()}");
        Console.WriteLine($"Perimeter: {shape.CalculatePerimeter()}");
        shape.Draw();


        //Task 2.6 - Calculator Method Overloading
        Console.WriteLine($"\n\nTask 2.6 - Calculator");
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Circle(5));
        shapes.Add(new Rectangle(10, 5));
        shapes.Add(new Circle(3));

        foreach (Shape sh in shapes)
        {
            Console.WriteLine(
                $"Area: {sh.CalculateArea()}"
            );
        }


        //Task 2.7 - Money
        Console.WriteLine($"\n\nTask 2.6 - Money");
        Money money1 = new Money(100, "USD");
        Money money2 = new Money(50, "USD");

        // +
        Money total = money1 + money2;

        Console.WriteLine($"Total: {total}");

        // ==
        Console.WriteLine( $"money1 == money2: {money1 == money2}" );

        // !=
        Console.WriteLine( $"money1 != money2: {money1 != money2}" );

        // >
        Console.WriteLine( $"money1 > money2: {money1 > money2}" );

        // <
        Console.WriteLine( $"money1 < money2: {money1 < money2}");

        // Currency mismatch
        Money euro = new Money(100, "EUR");

        try
        {
            Money result = money1 + euro;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine( $"Error: {ex.Message}" );
        }

    }
}