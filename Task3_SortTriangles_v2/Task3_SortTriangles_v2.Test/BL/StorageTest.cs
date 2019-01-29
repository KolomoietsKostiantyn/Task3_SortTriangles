using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task3_SortTriangles_v2.BL;
using Task3_SortTriangles_v2.Test.Aditional;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class StorageTest
    {
        Mock<IReversSorter> _rSorter;
        Mock<ITrianglCreator> _tCreator;
        Storage st;

        [TestInitialize]
        public void Initilize()
        {
            _rSorter = new Mock<IReversSorter>();
            _tCreator = new Mock<ITrianglCreator>();
            st = new Storage(_rSorter.Object, _tCreator.Object);
        }

        [TestMethod]
        public void AddTriangl_ValidData_True()
        {
            string name = "sd";
            double side1 = 5.0;
            double side2 = 5.5;
            double side3 = 5.6;
            List<Triangle> expectedTriangle = new List<Triangle>();
            expectedTriangle.Add(new Triangle(name, side1, side2, side3));

            _tCreator.Setup(x => x.CreateNew(name, side1, side2, side3)).Returns(() => new Triangle(name, side1, side2, side3));
            bool resuls = st.AddTriangl(name, side1, side2, side3);


            TriangleCompare triangleCompare = new TriangleCompare();
            Assert.IsTrue(resuls);
            CollectionAssert.AreEqual(expectedTriangle, st._triangls, triangleCompare);
        }

        [TestMethod]
        public void AddTriangl_EmptyStringName_False()
        {
            string name = string.Empty;
            double side1 = 5.0;
            double side2 = 5.5;
            double side3 = 5.6;

            _tCreator.Setup(x => x.CreateNew(name, side1, side2, side3)).Returns(() => null);

            bool resuls = st.AddTriangl(name, side1, side2, side3);

            Assert.IsFalse(resuls);
            Assert.AreEqual(0,st._triangls.Count);
        }

        [TestMethod]
        public void AddTriangl_CreateNewCall()
        {
            string name = "qq";
            double side1 = 5.0;
            double side2 = 5.5;
            double side3 = 5.6;

            _tCreator.Setup(x => x.CreateNew(name, side1, side2, side3)).Returns(() => null);

            st.AddTriangl(name, side1, side2, side3);

            _tCreator.Verify(x => x.CreateNew(name , side1, side2, side3));
        }

        [TestMethod]
        public void GetReversSortedList_ReversSort_Ok()
        {
            List<Triangle> expected = new List<Triangle>();
            expected.Add(new Triangle("tr5", 15, 15, 15));
            expected.Add(new Triangle("tr4", 12, 12, 12));
            expected.Add(new Triangle("tr3", 10, 10, 10));
            expected.Add(new Triangle("tr2", 8, 8, 8));
            expected.Add(new Triangle("tr1", 5, 5, 5));

            List<Triangle> inner = new List<Triangle>();
            inner.Add(new Triangle("tr1", 5, 5, 5));
            inner.Add(new Triangle("tr2", 8, 8, 8));
            inner.Add(new Triangle("tr3", 10, 10, 10));
            inner.Add(new Triangle("tr4", 12, 12, 12));
            inner.Add(new Triangle("tr5", 15, 15, 15));


            List<Triangle> reverseSortedResult = new List<Triangle>();
            reverseSortedResult.Add(new Triangle("tr5", 15, 15, 15));
            reverseSortedResult.Add(new Triangle("tr4", 12, 12, 12));
            reverseSortedResult.Add(new Triangle("tr3", 10, 10, 10));
            reverseSortedResult.Add(new Triangle("tr2", 8, 8, 8));
            reverseSortedResult.Add(new Triangle("tr1", 5, 5, 5));
            _rSorter.Setup(x => x.ReversSort(It.IsAny<List<Triangle>>())).Returns(() => reverseSortedResult);
            int trianglNum = 0;
            _tCreator.Setup(x => x.CreateNew(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(() => st._triangls[trianglNum]).Callback(() => trianglNum++);
            List<Triangle> result = st.GetReversSortedList();
   
            TriangleCompare triangleCompare = new TriangleCompare();

            _tCreator.Verify(x => x.CreateNew(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Exactly(st._triangls.Count));
            _rSorter.Verify(x => x.ReversSort(It.IsAny<List<Triangle>>()));
            CollectionAssert.AreEqual(expected, result, triangleCompare);
            Assert.AreNotEqual(st._triangls, result);
        }



    }   
}
