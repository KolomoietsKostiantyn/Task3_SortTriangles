using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_SortTriangles_v2.BL;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class TrianglCreatorTest
    {
        [TestMethod]
        public void CreateNew_CorectData_OK()
        {
            string name = "ff";
            double side1 = 5;
            double side2 = 5;
            double side3 = 5;

            TrianglCreator trianglCreator = new TrianglCreator();
            Triangle triangle = trianglCreator.CreateNew(name, side1, side2, side3);

            Assert.IsNotNull(triangle);
        }


        [TestMethod]
        public void CreateNew_WrongZize_Null()
        {
            string name = "ff";
            double side1 = 5;
            double side2 = 5;
            double side3 = 50;

            TrianglCreator trianglCreator = new TrianglCreator();
            Triangle triangle = trianglCreator.CreateNew(name, side1, side2, side3);

            Assert.IsNull(triangle);
        }

        [TestMethod]
        public void CreateNew_MinusZize_Null()
        {
            string name = "ff";
            double side1 = -5;
            double side2 = -5;
            double side3 = -5;

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

        [TestMethod]
        [DataRow(5.0,5.0,5.0,true)]
        [DataRow(5.0, 0.0, 5.0, false)]
        [DataRow(0.0, 0.0, 0.0, false)]
        [DataRow(-5.0, -5.0, -5.0, false)]
        public void ValidateTrianglSide_CorectData_OK(double side1, double side2, double side3, bool expected)
        {

            TrianglCreator trianglCreator = new TrianglCreator();
            bool result = trianglCreator.ValidateTrianglSide( side1, side2, side3);

            Assert.AreEqual(result, expected);

        }
    }
}
