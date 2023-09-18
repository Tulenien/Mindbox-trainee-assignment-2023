using Figures;

namespace FiguresTests
{
    public static class ObjectMother
    {
        public static IFigure CreateCircleWithRadius(double radius)
        {
            return new Circle(radius);
        }

        public static IFigure CreateValidCircle()
        {
            return new Circle(1);
        }

        public static IFigure CreateInvalidCircle()
        {
            return new Circle(-1);
        }

        public static IFigure CreateRightTriagle()
        {
            // Area is 6
            return new Triangle(3, 4, 5);
        }

        public static IFigure CreateTriangleWithSides(double a, double b, double c)
        {
            return new Triangle(a, b, c);
        }

        public static IFigure CreateIsoscelesTriangle()
        {
            // Area is 1
            double side = Math.Sqrt(2);
            return new Triangle(side, side, 2);
        }

        public static IFigure CreateEquilateralTriangle()
        {
            // Area is 3
            double side = 2 * Math.Pow(3, 0.25);
            return new Triangle(side, side, side);
        }

        public static IFigure CreateObtuseTriangle()
        {
            // Area is approximately 31.5268
            return new Triangle(6, 11, 14);
        }

        public static IFigure CreateValidTriangle()
        {
            return new Triangle(2, 3, 2);
        }

        public static IFigure CreateInvalidTriangle()
        {
            return new Triangle(1, 1, 2);
        }

        public static IFigure CreateTriangleWithZeroSide()
        {
            return new Triangle(0, 1, 2);
        }

        public static IFigure CreateTriangleWithNegativeSide()
        {
            return new Triangle(-1, 2, 2);
        }
    }
}
