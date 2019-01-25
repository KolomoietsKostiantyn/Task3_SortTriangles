using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task3_SortTriangles_v2.BL;

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

            _tCreator.Setup(x => x.CreateNew(name, side1, side2, side3)).Returns(() => new Triangle(name, side1, side2, side3));

            bool resuls = st.AddTriangl(name, side1, side2, side3);

            Assert.IsTrue(resuls);
        }

        [TestMethod]
        public void AddTriangl_EmptyString_False()
        {
            string name = string.Empty;
            double side1 = 5.0;
            double side2 = 5.5;
            double side3 = 5.6;

            _tCreator.Setup(x => x.CreateNew(name, side1, side2, side3)).Returns(() => null);

            bool resuls = st.AddTriangl(name, side1, side2, side3);

            Assert.IsFalse(resuls);
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
        public void GetReversSortedList_ReversSortCall()
        {
            List<Triangle> ss = new List<Triangle>();
            _rSorter.Setup(x => x.ReversSort(It.IsAny<List<Triangle>>())).Returns(It.IsAny<List<Triangle>>());

            st.GetReversSortedList();

            _rSorter.Verify(x => x.ReversSort(It.IsAny<List<Triangle>>()));
        }

    }
}
