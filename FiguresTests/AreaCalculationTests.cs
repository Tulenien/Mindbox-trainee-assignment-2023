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
            IFigure circle = new Circle(radius);

            double expected = Math.PI * radius * radius;
            double actual = circle.CalculateArea();

            Assert.AreEqual(expected, actual);
        }
    }
}