using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_SortTriangles_v2.BL;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class TrianglCreatorTest
    {
        [TestMethod]
        [DataRow("isosceles triangle", 0.1, 0.1, 0.1)]
        [DataRow("versatile triangle", 10.1, 15.1, 20.1)]
        [DataRow("right triangle", 3.0, 4.0, 5.0)]
        [DataRow("triangle", 3.6, 4.0, 7.0)]
        public void CreateNew_CorectData_OK(string name, double side1, double side2, double side3)
        {
            TrianglCreator trianglCreator = new TrianglCreator();
            Triangle triangle = trianglCreator.CreateNew(name, side1, side2, side3);

            Assert.IsNotNull(triangle);
        }

        [TestMethod]
        [DataRow("ff", 50.0, 5.0, 5.0)]
        [DataRow("ff", 5.0, 50.0, 5.0)]
        [DataRow("ff", 5.0, 5.0, 50.0)]
        public void CreateNew_OneSideTooBig_Null(string name, double side1, double side2, double side3)
        {

            TrianglCreator trianglCreator = new TrianglCreator();
            Triangle triangle = trianglCreator.CreateNew(name, side1, side2, side3);

            Assert.IsNull(triangle);
        }

        [TestMethod]
        [DataRow("ff", -1.0, 0.1, 0.1)]
        [DataRow("ff", 5.0, -5.0, 5.0)]
        [DataRow("ff", 5.0, 5.0, -5.0)]
        public void CreateNew_MinusSizeSide_Null(string name, double side1, double side2, double side3)
        {
            TrianglCreator trianglCreator = new TrianglCreator();
            Triangle triangle = trianglCreator.CreateNew(name, side1, side2, side3);

            Assert.IsNull(triangle);
        }

        [TestMethod]
        public void CreateNew_EmptyString_Null()
        {
            string name = " ";
            double side1 = 5;
            double side2 = 5;
            double side3 = 5;

            TrianglCreator trianglCreator = new TrianglCreator();
            Triangle triangle = trianglCreator.CreateNew(name, side1, side2, side3);

            Assert.IsNull(triangle);
        }
    }
}
