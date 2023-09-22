using Figures;

namespace FiguresTests
{
    [TestClass]
    public class TriangleLongestSidePrivateTests
    {
        [TestMethod]
        public void TriangleLongestSideHasIndex0()
        {
            IFigure triangle = ObjectMother.CreateTriangleWithLongestSideAtIndex0();
            PrivateObject obj = new PrivateObject(triangle);
            int expected = 0;
            int actual = -1;
            if (obj != null)
            {
                actual = (int)obj.Invoke("GetIndexOfTheLongestSide");
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TriangleLongestSideHasIndex1()
        {
            IFigure triangle = ObjectMother.CreateTriangleWithLongestSideAtIndex1();
            PrivateObject obj = new PrivateObject(triangle);
            int expected = 1;
            int actual = -1;
            if (obj != null)
            {
                actual = (int)obj.Invoke("GetIndexOfTheLongestSide");
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TriangleLongestSideHasIndex2()
        {
            IFigure triangle = ObjectMother.CreateTriangleWithLongestSideAtIndex2();
            PrivateObject obj = new PrivateObject(triangle);
            int expected = 2;
            int actual = -1;
            if (obj != null)
            {
                actual = (int)obj.Invoke("GetIndexOfTheLongestSide");
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EquilateralTriangleLongestSideHasIndex1()
        {
            IFigure triangle = ObjectMother.CreateEquilateralTriangle();
            PrivateObject obj = new PrivateObject(triangle);
            int expected = 1;
            int actual = -1;
            if (obj != null)
            {
                actual = (int)obj.Invoke("GetIndexOfTheLongestSide");
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsoscalesTriangleStartSidesLongestSideHasIndex2()
        {
            IFigure triangle = ObjectMother.CreateIsoscelesTriangleStartSides();
            PrivateObject obj = new PrivateObject(triangle);
            int expected = 2;
            int actual = -1;
            if (obj != null)
            {
                actual = (int)obj.Invoke("GetIndexOfTheLongestSide");
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsoscalesTriangleEndSidesLongestSideHasIndex0()
        {
            IFigure triangle = ObjectMother.CreateIsoscelesTriangleEndSides();
            PrivateObject obj = new PrivateObject(triangle);
            int expected = 0;
            int actual = -1;
            if (obj != null)
            {
                actual = (int)obj.Invoke("GetIndexOfTheLongestSide");
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
