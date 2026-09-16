namespace OOPsConcept2.UnderstandShapes
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

        // Implement abstract method
        public override double CalculateArea()
        {
            return Length * Width;
        }
    }
}
