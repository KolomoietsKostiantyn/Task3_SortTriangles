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
            string name = "";
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
            string name = "";
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
            string name = "";
            double side1 = -5;
            double side2 = -5;
            double side3 = -5;

            TrianglCreator trianglCreator = new TrianglCreator();
            Triangle triangle = trianglCreator.CreateNew(name, side1, side2, side3);

            Assert.IsNull(triangle);
        }



        [TestMethod]
        public void ValidateTrianglSide_CorectData_OK()
        {
            double side1 = 5;
            double side2 = 5;
            double side3 = 5;

            TrianglCreator trianglCreator = new TrianglCreator();
            bool result = trianglCreator.ValidateTrianglSide( side1, side2, side3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateTrianglSide_OneZeroValue_False()
        {
            double side1 = 0;
            double side2 = 5;
            double side3 = 5;

            TrianglCreator trianglCreator = new TrianglCreator();
            bool result = trianglCreator.ValidateTrianglSide(side1, side2, side3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateTrianglSide_AllZeroValue_False()
        {
            double side1 = 0;
            double side2 = 0;
            double side3 = 0;

            TrianglCreator trianglCreator = new TrianglCreator();
            bool result = trianglCreator.ValidateTrianglSide(side1, side2, side3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateTrianglSide_MinusValue_False()
        {
            double side1 = -5;
            double side2 = -5;
            double side3 = -5;

            TrianglCreator trianglCreator = new TrianglCreator();
            bool result = trianglCreator.ValidateTrianglSide(side1, side2, side3);

            Assert.IsFalse(result);
        }


    }
}
