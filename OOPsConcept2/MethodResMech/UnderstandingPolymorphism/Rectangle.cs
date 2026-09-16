namespace OOPsConcept2.MethodResMech.UnderstandingPolymorphism
{
    public class Rectangle : Shape
    {
        private double Length;
        private double Width;

        // Constructor
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        // Override
        public override double CalculateArea()
        {
            return Length * Width;
        }
    }
}
