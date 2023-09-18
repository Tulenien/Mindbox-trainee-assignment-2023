namespace Figures
{
    public class Triangle : IFigure
    {
        private double[] _sides = new double[3];

        public Triangle(double a, double b, double c)
        {
            _sides[0] = a;
            _sides[1] = b;
            _sides[2] = c;
        }

        private double CalculateSemiPerimeter(double a, double b, double c)
        {
            //return (a + b + c) / 2;
            return (a + b + c) * 0.5;
        }

        private int GetIndexOfTheLongestSide()
        {
            double a = _sides[0];
            double b = _sides[1];
            double c = _sides[2];

            if (a > b)
            {
                if (b > c)
                {
                    return 0;
                }
                else if (c > a)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            else if (c > b)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        private bool CheckIfRight()
        {
            int longestSideIndex = GetIndexOfTheLongestSide();
            double longest = 0, a = 0, b = 0;
            switch (longestSideIndex)
            {
                case 0:
                    longest = _sides[0];
                    a = _sides[1];
                    b = _sides[2];
                    break;
                case 1:
                    longest = _sides[1];
                    a = _sides[0];
                    b = _sides[2];
                    break;
                case 2:
                    longest = _sides[2];
                    a = _sides[0];
                    b = _sides[1];
                    break;
            }
            return longest * longest == a * a + b * b;
        }

        private double CalculateAreaOfRightTriangle()
        {
            int longestSideIndex = GetIndexOfTheLongestSide();
            double a = 0, b = 0;
            switch (longestSideIndex)
            {
                case 0:
                    a = _sides[1];
                    b = _sides[2];
                    break;
                case 1:
                    a = _sides[0];
                    b = _sides[2];
                    break;
                case 2:
                    a = _sides[0];
                    b = _sides[1];
                    break;
            }
            return 0.5 * a * b;
        }

        public double CalculateArea()
        {
            if (CheckIfRight() != true)
            {
                double a = _sides[0];
                double b = _sides[1];
                double c = _sides[2];
                double semiPerimeter = CalculateSemiPerimeter(a, b, c);
                return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
            }
            else
            {
                return CalculateAreaOfRightTriangle();
            }
        }
    }
}
