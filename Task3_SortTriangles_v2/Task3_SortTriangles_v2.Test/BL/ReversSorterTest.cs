using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_SortTriangles_v2.BL;
using Task3_SortTriangles_v2.Test.Aditional;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class ReversSorterTest
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ReversSort_NullInnerParam_Error()
        {
            List<Triangle> triangles = null;
            ReversSorter reversSorter = new ReversSorter();
            reversSorter.ReversSort(triangles);
        }

        [TestMethod]
        public void ReversSort_ValidData_Ok()
        {
            List<Triangle> triangles = new List<Triangle>();
            triangles.Add(new Triangle("t1", 1, 1, 1));
            triangles.Add(new Triangle("t2", 2, 2, 2));
            triangles.Add(new Triangle("t3", 14, 14, 14));
            triangles.Add(new Triangle("t4", 6, 6, 6));
            triangles.Add(new Triangle("t5", 8, 8, 8));
            triangles.Add(new Triangle("t6", 22, 22, 22));

            ReversSorter reversSorter = new ReversSorter();
            List<Triangle> reverseSortedList = reversSorter.ReversSort(triangles);


            List<Triangle> validL = new List<Triangle>();
            validL.Add(new Triangle("t6", 22, 22, 22));
            validL.Add(new Triangle("t3", 14, 14, 14));
            validL.Add(new Triangle("t5", 8, 8, 8));
            validL.Add(new Triangle("t4", 6, 6, 6));
            validL.Add(new Triangle("t2", 2, 2, 2));
            validL.Add(new Triangle("t1", 1, 1, 1));


            TriangleCompare tCompare = new TriangleCompare();

            CollectionAssert.AreEqual(validL, reverseSortedList, (IComparer)tCompare);
        }

      

    }
}
