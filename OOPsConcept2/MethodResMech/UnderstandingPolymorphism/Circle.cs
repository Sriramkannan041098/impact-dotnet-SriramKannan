namespace OOPsConcept2.MethodResMech.UnderstandingPolymorphism
{
    public class Circle : Shape
    {
        private double Radius;

        // Constructor
        public Circle(double radius)
        {
            Radius = radius;
        }

        // Override
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
