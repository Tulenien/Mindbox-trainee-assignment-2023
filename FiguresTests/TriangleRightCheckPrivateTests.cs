using Figures;

namespace FiguresTests
{
    [TestClass]
    public class TriangleRightCheckPrivateTests
    {
        [TestMethod]
        public void TriangleIsRightShouldReturnTrue()
        {
            IFigure triangle = ObjectMother.CreateRightTriagle();
            PrivateObject obj = new PrivateObject(triangle);
            bool checkValue = false;
            if (obj != null)
            {
                checkValue = (bool)obj.Invoke("CheckIfRight");
            }
            Assert.IsTrue(checkValue);
        }

        [TestMethod]
        public void TriangleIsNotRightShouldReturnFalse()
        {
            IFigure triangle = ObjectMother.CreateNotRightTriangle();
            PrivateObject obj = new PrivateObject(triangle);
            bool checkValue = true;
            if (obj != null)
            {
                checkValue = (bool)obj.Invoke("CheckIfRight");
            }
            Assert.IsFalse(checkValue);
        }
    }
    
}
