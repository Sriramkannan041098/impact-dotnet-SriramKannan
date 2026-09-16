namespace OOPsConcept2.UnderstandingInterface
{
    public class DrawableShape : IShape, IDrawable
    {
        private double Length;
        private double Width;

        // Constructor
        public DrawableShape(double length, double width)
        {
            Length = length;
            Width = width;
        }

        // IShape implementation
        public double CalculateArea()
        {
            return Length * Width;
        }

        // IShape implementation
        public double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }

        // IDrawable implementation
        public void Draw()
        {
            Console.WriteLine("Drawing the shape...");
        }
    }
    }
