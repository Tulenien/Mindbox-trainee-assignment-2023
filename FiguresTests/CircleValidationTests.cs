using Figures;

namespace FiguresTests
{
    [TestClass]
    public class CircleValidationTests
    {
        [TestMethod]
        public void CircleIsValidShouldReturnTrue()
        {
            IFigure circle = ObjectMother.CreateValidCircle();
            bool checkValue = circle.CheckIfValid();
            Assert.IsTrue(checkValue);
        }

        [TestMethod]
        public void CircleIsInvalidShouldReturnFalse()
        {
            IFigure circle = ObjectMother.CreateInvalidCircle();
            bool checkValue = circle.CheckIfValid();
            Assert.IsFalse(checkValue);
        }

        [TestMethod]
        public void CircleWithZeroRadiusIsInvalid()
        {
            IFigure circle = ObjectMother.CreateCircleWithRadius(0);
            bool checkValue = circle.CheckIfValid();
            Assert.IsFalse(checkValue);
        }
    }
}
