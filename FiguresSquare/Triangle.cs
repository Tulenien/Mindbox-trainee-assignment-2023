namespace Figures
{
    public class Triangle : IFigure
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        private double CalculateSemiPerimeter() => (_sideA + _sideB + _sideC) / 2;

        public double CalculateArea()
        {
            double semiPerimeter = CalculateSemiPerimeter();
            return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
        }
    }
}
