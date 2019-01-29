using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_SortTriangles_v2.BL;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class TriangleTest
    {




        [TestMethod]
        [DataRow("isosceles triangle", 4, 4, 4)]
        [DataRow("versatile triangle", 10.1, 15.1, 20.1)]
        [DataRow("right triangle", 3.0, 4.0, 5.0)]
        [DataRow("triangle", 3.6, 4.0, 7.0)]
        public void Square(string name, double side1, double side2, double side3)
        {
            double halfPerimeter = (side1 + side2 + side3) / 2;
            double expected = Math.Sqrt(halfPerimeter * (halfPerimeter - side1) * (halfPerimeter - side2) * (halfPerimeter - side3));
            Triangle inner = new Triangle(name, side1, side2, side3);

            double result = inner.Square;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareTo_BiggerTriangle_MinusOne()
        {
            Triangle inner = new Triangle("tr1", 5, 5, 5);
            Triangle biggerTriangle = new Triangle("tr2", 15, 15, 15);
            int expected = -1;

            int result = inner.CompareTo(biggerTriangle);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareTo_LessTriangle_1()
        {
            Triangle inner = new Triangle("tr1", 15, 15, 15);
            Triangle biggerTriangle = new Triangle("tr2", 5, 5, 5);
            int expected = 1;

            int result = inner.CompareTo(biggerTriangle);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareTo_SameTriangle_0()
        {
            Triangle inner = new Triangle("tr1", 10, 10, 10);
            Triangle biggerTriangle = new Triangle("tr2", 10, 10, 10);
            int expected = 0;

            int result = inner.CompareTo(biggerTriangle);

            Assert.AreEqual(expected, result);
        }
    }
}
