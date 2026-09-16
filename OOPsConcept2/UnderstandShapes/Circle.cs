namespace OOPsConcept2.UnderstandShapes
{
    public class Circle : Shape
    {
        private double Radius;

        // Constructor
        public Circle(double radius)
        {
            Radius = radius;
        }

        // Implement abstract method
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
