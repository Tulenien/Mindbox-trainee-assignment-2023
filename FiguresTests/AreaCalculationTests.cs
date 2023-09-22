using Figures;

namespace FiguresTests
{
    [TestClass]
    public class AreaCalculationTests
    {
        [TestMethod]
        public void CalculateCircleArea()
        {
            double radius = 3;
            IFigure circle = ObjectMother.CreateCircleWithRadius(radius);

            double expected = Math.PI * radius * radius;
            double actual = circle.CalculateArea();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTriagleArea()
        {
            IFigure triagle = ObjectMother.CreateRightTriagle();

            double expected = 6;
            double actual = triagle.CalculateArea();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateIsoscelesTriangleArea()
        {
            IFigure triangle = ObjectMother.CreateIsoscelesTriangleStartSides();

            double expected = 1;
            double actual = triangle.CalculateArea();

            Assert.AreEqual(expected, Math.Round(actual, 6));
        }

        [TestMethod]
        public void CalculateEquilateralTriangleArea()
        {
            IFigure triangle = ObjectMother.CreateEquilateralTriangle();

            double expected = 3;
            double actual = triangle.CalculateArea();

            Assert.AreEqual(expected, Math.Round(actual, 6));
        }

        [TestMethod]
        public void CalculateObtuseTriangleArea()
        {
            IFigure triangle = ObjectMother.CreateObtuseTriangle();

            double expected = 3 * Math.Sqrt(1767) * 0.25;
            double actual = triangle.CalculateArea();

            Assert.AreEqual(Math.Round(expected, 6), Math.Round(actual, 6));
        }

        [TestMethod]
        public void CalculateInvalidTriangleAreaShouldReturnNegative1()
        {
            IFigure triangle = ObjectMother.CreateInvalidTriangle();

            double expected = -1;
            double actual = triangle.CalculateArea();

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CalculateInvalidCircleAreaShouldReturnNegative1()
        {
            IFigure circle = ObjectMother.CreateInvalidCircle();

            double expected = -1;
            double actual = circle.CalculateArea();

            Assert.AreEqual(actual, expected);
        }
    }
}