using Figures;

namespace FiguresTests
{
    [TestClass]
    public class TriangleValidationTests
    {
        [TestMethod]
        public void TriangleIsValidShouldReturnTrue()
        {
            IFigure triangle = ObjectMother.CreateValidTriangle();
            bool checkValue = triangle.CheckIfValid();
            Assert.IsTrue(checkValue);
        }

        [TestMethod]
        public void TriangleIsInvalidShouldReturnFalse()
        {
            IFigure triangle = ObjectMother.CreateInvalidTriangle();
            bool checkValue = triangle.CheckIfValid();
            Assert.IsFalse(checkValue);
        }

        [TestMethod]
        public void TriangleWithZeroSideIsInvalid()
        {
            IFigure triangle = ObjectMother.CreateTriangleWithZeroSide();
            bool checkValue = triangle.CheckIfValid();
            Assert.IsFalse(checkValue);
        }

        [TestMethod]
        public void TriangleWithNegativeSideIsInvalid()
        {
            IFigure triangle = ObjectMother.CreateTriangleWithNegativeSide();
            bool checkValue = triangle.CheckIfValid();
            Assert.IsFalse(checkValue);
        }
    }
}
